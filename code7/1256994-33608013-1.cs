    private static string ProcessAndTrimFooBar(string s, out bool foundAny)
    {
        foundAny = false;
        int fooStart = s.IndexOf("<foo", StringComparison.OrdinalIgnoreCase);
        int fooEnd = s.IndexOf("</foo>", StringComparison.OrdinalIgnoreCase);
        int barStart = s.IndexOf("<bar", StringComparison.OrdinalIgnoreCase);
        int barEnd = s.IndexOf("</bar>", StringComparison.OrdinalIgnoreCase);
        bool fooExists = fooStart >= 0 && fooEnd >= 0;
        bool barExists = barStart >= 0 && barEnd >= 0;
        if ((fooExists && !barExists) || (fooExists && barExists && fooStart < barStart))
        {
            string fooNodeContent = s.Substring(fooStart, fooEnd - fooStart + 6);
            s = s.Substring(fooEnd + 6);
            Console.WriteLine("Received <foo>: {0}", fooNodeContent);
            OnAlarmResponseComplete(new CustomEventArgs(fooNodeContent));
            foundAny = true;
        }
        if ((barExists && !fooExists) || (barExists && fooExists && barStart < fooStart))
        {
            string barNodeContent = s.Substring(barStart, barEnd - barStart + 6);
            s = s.Substring(barEnd + 6);
            Console.WriteLine("Received <bar>: {0}", barNodeContent);
            OnAckComplete(new CustomEventArgs(barNodeContent));
            foundAny = true;
        }
        return s;
    }
    public static void Start()
    {
        StreamReader reader = new StreamReader(_tcpClient.GetStream());
        char[] chars = new char[Int16.MaxValue];
        while (!_requestStop)
        {
            try
            {
                int currentOffset = 0;
                while ((reader.Read(chars, currentOffset, chars.Length - currentOffset)) != 0)
                {
                    string s = new string(chars).TrimEnd('\0');
                    bool foundAny;
                    do
                    {
                        s = ProcessAndTrimFooBar(s, out foundAny);
                    } while (foundAny);
                    chars = s.PadRight(Int16.MaxValue, '\0').ToCharArray();
                    currentOffset = s.Length;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //break;
            }
        }
        reader.Close();
        Console.WriteLine("Stopping TcpReader thread!");
    }
