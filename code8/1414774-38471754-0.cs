    using UnityEngine;
    using System.Collections;
    using UnityEngine;
    using System.Collections;
    using UnityEditor;
    using System;
    using System.IO;
    public class Testing : AssetPostprocessor
    {
        static string extension = ".csv";        // Our custom extension
        static string newExtension = ".cs";        // Extension of newly created asset - it MUST be ".asset", nothing else is allowed...
        public static bool HasExtension(string asset)
        {
            return asset.EndsWith(extension, System.StringComparison.OrdinalIgnoreCase);
        }
        public static string ConvertToInternalPath(string asset)
        {
            string left = asset.Substring(0, asset.Length - extension.Length);
            return left + newExtension;
        }
        // This is called always when importing something
        static void OnPostprocessAllAssets(
            string[] importedAssets,
            string[] deletedAssets,
            string[] movedAssets,
            string[] movedFromAssetPaths)
        {
            foreach (string asset in importedAssets)
            {
                // This is our detection of file - by extension
                if (HasExtension(asset))
                {
                    ImportMyAsset(asset);
                }
            }
        }
        // Imports my asset from the file
        static void ImportMyAsset(string asset)
        {
            // Path to out new asset
            string newPath = ConvertToInternalPath(asset);
            File.WriteAllText(newPath, "// works!");
        }
    }
