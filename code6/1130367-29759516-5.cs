            List<string> contentControlText = new List<string>();
            foreach(ContentControl CC in doc.ContentControls)
            {
                if (CC.Type == WdContentControlType.wdContentControlRichText)
                {
                    contentControlText.Add(CC.Range.Text);
                }
            }
