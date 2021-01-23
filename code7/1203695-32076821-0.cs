                                //destroyWorkSheet.Append(string.Format("{0}", "Directory" + fullName));
                                //destroyWorkSheet.Append(string.Format("{1}", "FileName" + fullName));
                               // destroyWorkSheet.AppendLine("Directory, FileName");
                               // destroyWorkSheet.Append(string.Format("{0},{1}", "Directory", "FileName") + fullName);
                                destroyWorksheet.AppendLine(fullName);
                          }
                        // Validate file for name (less than 200 chars, can't have TAB / \ : * ? " < > | ) and size ( less than 200 MB)
                        else if (invalidFileName || file.Length > 200000000 || file.Name.Length > 200)
                        {// This should cause the WHOLE upload to fail
                            System.Diagnostics.Debug.WriteLine("INVALID file: " + file.Name);
                            lblError.Text = lblError.Text + "\r\n" + "INVALID file: " + file.Name;
                            errorWorksheet.AppendLine("INVALID file: " + file.Name);
                        }
                        else if (unwantedExtensions.Contains(file.Extension.Replace(".", "").ToUpper()))
                        {// Files with unwanted extensions are filtered out
                            filterWorksheet.AppendLine(fullName);
                        }
