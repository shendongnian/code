    var result = this.Controls.OfType<TextBox>().Select(x =>
                     {
                         try { return new { Key = x, Value = Convert.ToInt32(x.Text) }; }
                         catch { return null; }
                     })
                     .Where(x=>x!=null)
                     .OrderByDescending(x => x.Value)
                     .Take(3)
                     .ToDictionary(x => x.Key, x => x.Value);
