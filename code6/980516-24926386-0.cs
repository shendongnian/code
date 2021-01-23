    <ul id="nav">
            @foreach (var p in Model.Where(a => a.MENU_MASTER.PARENT_ID == 0))
            {
    
                if (Model.Where(a => a.MENU_MASTER.PARENT_ID == p.MENU_MASTER.OBJECT_ID).Any())
                {
                <li class="has-sub"><a href="#">@p.MENU_MASTER.OBJECT_NAME</a>
                    <ul>
                        @foreach (var c in Model.Where(g => (g.MENU_MASTER.PARENT_ID == p.MENU_MASTER.OBJECT_ID)))
                        {
                            if (Model.Where(a => a.MENU_MASTER.PARENT_ID == c.MENU_MASTER.OBJECT_ID).Any())
                            {
                            <li class="has-sub"><a href="#"><span>@c.MENU_MASTER.OBJECT_NAME</span></a>
                                <ul>
                                    @foreach (var d in Model.Where(a => a.MENU_MASTER.PARENT_ID == c.MENU_MASTER.OBJECT_ID))
                                    {
                                        <li><a  href="@Url.Action(@d.MENU_MASTER.ACTION_NAME, @d.MENU_MASTER.CONTROLLER_NAME)">
                                            <span>@d.MENU_MASTER.OBJECT_NAME</span></a> </li>
                                    }
                                </ul>
                            </li>
                            
                            }
                            else
                            {
                            <li><a  href="@Url.Action(@c.MENU_MASTER.ACTION_NAME, @c.MENU_MASTER.CONTROLLER_NAME)">
                                <span>@c.MENU_MASTER.OBJECT_NAME</span></a> </li>  
                            }
    
                        }
                    </ul>
                </li>
                }
                else
                {
                <li><a class="hsubs" href="#">@p.MENU_MASTER.OBJECT_NAME</a></li>
                }
    
            }
        </ul>
