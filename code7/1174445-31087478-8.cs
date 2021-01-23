    public static void Traverse(int channelToAccess)
    {
                int maxChannels = 450;
                char[] invalidNums = { '2', '5', '8', '9' };
                int result = -1;      // closest channel num
    
                for (int i = 1; result == -1 && i > 0 && i < maxChannels; i++)
                {
                    if (!(channelToAccess+ i).ToString().Any(invalidNums.Contains)) { result = channelToAccess+ i; break; }
                    if (!(channelToAccess- i).ToString().Any(invalidNums.Contains)) { result = channelToAccess+ i; break; }
                }
               int difference = result - channelToAccess;
               Console.WriteLine("To go to channel {0} you should turn channel {1} and press {2} button {3} times, channelToAccess, result, difference > 0? "Next" : "Prev", Math.Abs(difference));
    
    }
   
