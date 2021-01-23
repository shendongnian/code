    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;    
    public static string getPathFromUser(string path)
        {
            if (File.Exists("test.txt"))
            {
                string k = Regex.Replace(File.ReadAllLines("test.txt").Single(d => d.ToLower().Contains(path.ToLower())), @"\w+:", "\0");
                return k != null || k != string.Empty ? k : "Unknown option.";
            }
            else
            {
                File.AppendAllText("test.txt", "home:");
                return "No file found, made one instead";
            }
        }
