        /// <summary>
        /// Combines the identical runs.
        /// </summary>
        /// <param name="body">The body.</param>
        public static void CombineIdenticalRuns(W.Body body)
        {
            List<W.Run> runsToRemove = new List<W.Run>();
            foreach (W.Paragraph para in body.Descendants<W.Paragraph>())
            {
                List<W.Run> runs = para.Elements<W.Run>().ToList();
                for (int i = runs.Count - 2; i >= 0; i--)
                {
                    W.Text text1 = runs[i].GetFirstChild<W.Text>();
                    W.Text text2 = runs[i + 1].GetFirstChild<W.Text>();
                    if (text1 != null && text2 != null)
                    {
                        string rPr1 = "";
                        string rPr2 = "";
                        if (runs[i].RunProperties != null) rPr1 = runs[i].RunProperties.OuterXml;
                        if (runs[i + 1].RunProperties != null) rPr2 = runs[i + 1].RunProperties.OuterXml;
                        if (rPr1 == rPr2)
                        {
                            text1.Text += text2.Text;
                            runsToRemove.Add(runs[i + 1]);
                        }
                    }
                }
            }
            foreach (W.Run run in runsToRemove)
            {
                run.Remove();
            }
        }
