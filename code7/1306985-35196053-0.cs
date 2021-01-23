                     int count1 = 0;
                     int count2 = 0;
                     foreach (Word.Bookmark bookmark1 in wordDocument.Bookmarks)
                     {
                          Word.Range bmRange = bookmark1.Range;
                          //bmRange.Text = "заметка" + count1;
                          listOfRanges.Add(bmRange);
                          count1++; 
                     }
                     foreach (Word.Bookmark bookmark2 in wordPattern.Bookmarks)
                     {
                          Word.Range mbRange = bookmark2.Range;
                          mbRange.Text = listOfRanges[count2].Text;
                          count2++;
                     }
