    var html = @"<div>
        <div>
            <div>
                line1
            </div>
        </div>
    </div>
    <div>line2</div>";
    
    var lines = CQ.Create(html)
                  .Text()
                  .Replace("\r\n", "\n") // I like to do this before splitting on line breaks
                  .Split('\n')
                  .Select(s => s.Trim()) // Trim elements
                  .Where(s => !s.IsNullOrWhiteSpace()) // Remove empty lines
                  ;
    
    var result = string.Join(Environment.NewLine, lines);
