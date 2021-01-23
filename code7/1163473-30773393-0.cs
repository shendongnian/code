    for (var j = 0; j < searchTermArray.Length; j++)
                        {
                            CompareInfo ci = CultureInfo.CurrentCulture.CompareInfo;
                            int indexOfTerm = ci.IndexOf(text, searchTermArray[j], CompareOptions.IgnoreCase);
                            //dont replace if there is no search term in text
                            if(indexOfTerm!= -1)
                            {
                                string subStringToHighlight = text.Substring(indexOfTerm, searchTermArray[j].Length);
                                //replacing with span
                                string replaceWith = string.Format("<span class='highlight-search-text'>{0}</span>", subStringToHighlight);
                                text = Regex.Replace(text, searchTermArray[j], replaceWith, RegexOptions.IgnoreCase);
                            }
                            
                        }
