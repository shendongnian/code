            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int a = 0; a < e.Row.Cells.Count; a++)
                {
                    if (e.Row.Cells[a].GetType() == typeof(DataControlFieldCell))
                    {
                        var fc = e.Row.Cells[a] as DataControlFieldCell;
                        var st = <YOUR_SEARCH_TEXT>;
                        if (fc != null && !String.IsNullOrEmpty(st) && fc.Text.Contains(st))
                        {
                            var txt = fc.Text;
                            var begin = txt.Substring(0, txt.IndexOf(st));
                            var end = txt.Substring(txt.IndexOf(st) + st.Length);
                            fc.Text = begin + "<span class='matchedText'>" + st + "</span>" + end;
                        }
                    }
                }
            }
        }`
