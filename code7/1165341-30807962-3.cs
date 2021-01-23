                /// <summary>
                /// Splits the string by the "'" char and gets the first entry.
                /// </summary>
                /// <param name="x"></param>
                /// <returns></returns>
                private static string GetFirstEntry(string x)
                {
                 try{
                    return x.Split(new string[] { "'" }, StringSplitOptions.RemoveEmptyEntries)[0].Trim();
                    }catch{return string.empty;}
                }
