            /// <summary>
            /// Convert a ListView to an array of string
            /// </summary>
            /// <param name="ListView1"></param>
            /// <returns>an array of strings</returns>
            private string[] ConvertToArray(ListView ListView1)
            {
                string[] array = new string[ListView1.Items.Count];
                for (int i = 0; i <= ListView1.Items.Count - 1; i++)
                {
                    array[i] = ListView1.Items[i].Text;
                }
                return array;
            }   
