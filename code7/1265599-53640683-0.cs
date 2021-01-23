    namespace RecordConsoleProgress
    {
        using System.Collections.Generic;
        using static System.Console;
        class Program
        {
            static List<string> recording = new List<string>();
            static void Main(string[] args)
            {
                string response = "";
                do
                {
                    string prompt = "Please enter your input (Q <ENTER> to Quit): ";
                    Write(prompt);
                    recording.Add(prompt);
                    response = ReadLine();
                    recording.Add(response);
                } while (response != "Q");
                WriteLine("\nYour recording follows");
                foreach (string s in recording)
                    WriteLine(s);
                ReadLine();
            }
        }
    }
