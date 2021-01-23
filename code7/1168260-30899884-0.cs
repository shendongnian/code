    @foreach(var col in @item.cols)
    {
       if (!string.IsNullOrEmpty(col.Col1))
       {
           <div>@col.Col1</div>
       }
       if (!string.IsNullOrEmpty(col.Col2))
       {
           <div>@col.Col2</div>
       }
       if (!string.IsNullOrEmpty(col.Col3))
       {
           <div>@col.Col3</div>
       }
    }
