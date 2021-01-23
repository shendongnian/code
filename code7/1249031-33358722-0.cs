                    if (elementCollection[i].Current.Name.ToUpper().IndexOf("ROW") >= 0)
                    {
                        AutomationElement mDest = Share.GetElementByNameFromChild(elementCollection[i], ColumnName);
                        var pattern = ((LegacyIAccessiblePattern)mDest.GetCurrentPattern(LegacyIAccessiblePattern.Pattern));
                        String state = pattern.Current.Value;
                        if (Share.CompareString(state, SearchString))
                        {
                            watch.Stop();
                            var elapsedMs = watch.Elapsed.TotalSeconds;
                            FileAdapter.WriteLog("Search value in Table col " + ColumnName + " and search string:  " + SearchString + "," + true.ToString() + "," + elapsedMs);
                            Share.wait(Utility.delayTime());
                            return true;
                        }
                    }
                }
