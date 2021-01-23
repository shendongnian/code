    @Model Iterator
    <div>
        @{
            var numCount = Model.x;
            var colCount = Model.y;
            for (int i = 1; i < numCount; i++)
            {
                <span>@i</span>
                Do more stuff here.
               
            }
        }
    </div>
