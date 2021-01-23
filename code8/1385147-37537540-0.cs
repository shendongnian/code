    #region //Remove files with the extensions in the list.
        public static void deleteFileExtensions(List<string> fileExtensionsToRemove, string filepath)
        {
            try
            {
                /*Get the extension by splitting by the final period.*/
                string tocompare = Regex.Split(Path.GetFileName(filepath), @".*\.")[1];
                /*For every element in the list, if one of the extensions matches the file extension, delete*/
                fileExtensionsToRemove.ForEach(x => { if (tocompare.Contains(x)) File.Delete(filepath); });
            }
            catch(IOException ex) { Console.WriteLine(ex); }
        }
        #endregion
