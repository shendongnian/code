       private void MakeThePrintOut()
        {
            RichTextBlock gutOne = initBlock();
            PopulateBlock(gutOne);
            ContentStack.Children.Add(gutOne);
           
            
        }
        private RichTextBlock initBlock()
        {
            RichTextBlock gutInitBlock = new RichTextBlock();
            gutInitBlock.Foreground = new SolidColorBrush(Windows.UI.Colors.Black);
            gutInitBlock.FontSize = 18;
            gutInitBlock.OverflowContentTarget = FirstLinkedContainer;
            gutInitBlock.FontFamily = new FontFamily("Courier New");
            gutInitBlock.VerticalAlignment = VerticalAlignment.Top;
            gutInitBlock.HorizontalAlignment = HorizontalAlignment.Left;
            return gutInitBlock;
        }
        private void PopulateBlock( RichTextBlock Blocker)
        {
            bool firstItem = true;
            int firstLength = 0;
            Paragraph paraItem = null;
            Run itemRun = null;
            string CurrentIsle = "None";
            foreach( Grocery j in Grocs)
            {
                if (j.Isle != CurrentIsle)
                {
                    if ((CurrentIsle != "None") && (!firstItem))
                    {
                        paraItem.Inlines.Add(itemRun);
                        Blocker.Blocks.Add(paraItem);
                    }
                    CurrentIsle = j.Isle;
                    firstItem = true;
                    Paragraph paraIsle = new Paragraph();
                    Run paraRan = new Run();
                    paraRan.Text = "     " + j.Isle;
                    paraIsle.Inlines.Add(paraRan);
                    Blocker.Blocks.Add(paraIsle);
                }
               if (firstItem)
                {
                    paraItem = new Paragraph();
                    itemRun = new Run();
                    itemRun.Text = "        [] " + j.Item;
                    firstLength = j.Item.Length;
                    firstItem = false;
                } else
                {
                    firstItem = true;
                    string s = new string(' ', 30 - firstLength);
                    itemRun.Text += s + "[] " +  j.Item;
                    paraItem.Inlines.Add(itemRun);
                    Blocker.Blocks.Add(paraItem);
                }
               
                
                }
            if (!firstItem)
            {
                paraItem.Inlines.Add(itemRun);
                Blocker.Blocks.Add(paraItem);
            }
        }
