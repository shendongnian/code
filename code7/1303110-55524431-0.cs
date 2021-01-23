    using System.IO;
    using System.Text.RegularExpressions;
    using UnityEngine;
    using UnityEditor;
    [InitializeOnLoad]
    class FixCSProjs : AssetPostprocessor
    {
        private static void OnGeneratedCSProjectFiles() {
            Debug.Log("Fixing csproj files...");
            var dir = Directory.GetCurrentDirectory();
            var files = Directory.GetFiles(dir, "*.csproj");
            
            foreach (var file in files) {
                FixProject(file);
            }
        }
        
        static bool FixProject(string file) {
            var text = File.ReadAllText(file);
            var find = "<NoWarn>([0-9;]+)<\\/NoWarn>";
            var replace = "<NoWarn>$1;3003;3009</NoWarn>";
            
            if (Regex.IsMatch(text, find)) {
                text = Regex.Replace(text, find, replace);
                File.WriteAllText(file, text);
                return true;
                
            } else {
                return false;
            }
        }
    }
