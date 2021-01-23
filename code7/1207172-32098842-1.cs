        public struct SortingTraceInfo
        {
          public int Position;
          public int TargetPosition;
          public int[] SortingNumbers;
        }
        public int[] Sorting = new[] { 23, 59, 59, 70, 12, 92, 19, 14, 77, 51 };        
        public List<SortingTraceInfo> SortingInfos=new List<SortingTraceInfo>();
        private void Next_OnClick(object sender, RoutedEventArgs e)
        {            
            Output.Document.Blocks.Clear();
            for (int j = 0; j < Sorting.Count()-1; j++)
            {
                if (Sorting[j] > Sorting[j + 1])
                {                   
                    //render to RTB
                    for (int i = 0; i < Sorting.Count(); i++)
                    {
                        if (i==j)
                        {
                            //render the number red 
                            var textRange = new TextRange(Output.Document.ContentEnd, Output.Document.ContentEnd);
                            textRange.Text = Sorting[i] + " ";
                            textRange.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Red);                            
                        }
                        else if(i==j+1)
                        {
                            //render the number blue 
                            var textRange = new TextRange(Output.Document.ContentEnd, Output.Document.ContentEnd);
                            textRange.Text = Sorting[i]+ " ";
                            textRange.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Blue); 
                            
                        }
                        else
                        {
                            //render the number black 
                            var textRange = new TextRange(Output.Document.ContentEnd, Output.Document.ContentEnd);
                            textRange.Text = Sorting[i] + " ";
                            textRange.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Black);                             
                        }
                    }
                    //Swap(Sorting, j, j + 1);
                    int tmp=Sorting[j];
                    Sorting[j] = Sorting[j+1];
                    Sorting[j + 1] = tmp;
                    var sortInfo = new SortingTraceInfo(); // struct Variable
                    sortInfo.Position = j; // change position save
                    sortInfo.TargetPosition = j + 1; // changed position save
                    sortInfo.SortingNumbers = Sorting.ToArray(); // 
                    SortingInfos.Add(sortInfo);
                    //handle one sorting operation one at a time 
                    break;
                }               
            }           
        }
