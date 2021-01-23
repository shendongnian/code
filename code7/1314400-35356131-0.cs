    @foreach (var item in Model
                         .Select(m => new { Rid = m.Rid, m.Pdv, Total =m.Total * m.Quantity})
                         .GroupBy(g => new { g.Rid, g.Pdv} )
                         .Select(s => new 
                         { 
                             Rid = s.Key.Rid, 
    						 Pdv = s.Key.Pdv, 
                             Total = s.Sum(t => t.Total) 
                         }))
    {
       <input value="@item" />
    }
	
