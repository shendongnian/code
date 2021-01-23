     void CellText()
     {
         using (var window = StartScenario("OpenListView", "ListViewWindow"))
         {
             var listView = window.Get<ListView>("ListView");
             ListViewRow first = listView.Rows[0];
             Assert.Equal("Search", first.Cells[0].Text);
             Assert.Equal("Google", first.Cells[1].Text);
             ListViewRow second = listView.Rows[1];
             Assert.Equal("Mail", second.Cells[0].Text);
             Assert.Equal("GMail", second.Cells[1].Text);
         }
     }
