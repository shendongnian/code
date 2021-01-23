    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;
    public class Test
    {
        public string[] TestInput = new string[]
        {
            @"rootuploaded\samplefolder\1232_234234_1.jpg",
            @"rootuploaded\samplefolder\1232_234234_2.bmp",
            @"rootuploaded\file-5.txt",
            @"rootuploaded\file-67.txt",
            @"rootuploaded\file-a.txt",
            @"rootuploaded\file1.txt",
            @"rootuploaded\file2.txt",
            @"rootuploaded\file5.txt",
            @"rootuploaded\filea.txt",
            @"rootuploaded\file_sample.txt",
            @"rootuploaded\file_sample_a.txt"
        };
        public string[] RegularExpressions = new string[]
        {
            "[A-Za-z_]+",
            "[A-Za-z-]+",
            "[A-Za-z]+_[0-9]+",
            "[A-Za-z]+-[0-9]+",
            "[A-Za-z]+ [0-9]+",
            "[A-Za-z]+[0-9]+"
        };
        public List<List<string>> CreateGroups(string[] inputs)
        {
            List<List<string>> output = new List<List<string>>(RegularExpressions.Length);
            for (int i = 0; i < RegularExpressions.Length; ++i)
                output.Add(new List<string>());
            foreach (string input in inputs)
            {
                string filename = Path.GetFileNameWithoutExtension(input);
                for (int i = 0; i < RegularExpressions.Length; ++i)
                {
                    Match match = Regex.Match(filename, RegularExpressions[i]);
                    if (match.Success && match.Length == filename.Length)
                    {
                        output[i].Add(input);
                        break;
                    }
                }
            }
            return output;
        }
    }
