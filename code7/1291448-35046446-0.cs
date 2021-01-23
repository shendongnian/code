    @foreach (var item in Model)
                {
                    if (item.isParent == false && item.parentId == 0)
                    {
                        <li><a href="@Url.Action(item.action, item.controller)"><i class="@item.imageClass"></i> @item.nameOption</a></li>
                    }                    
                    else
                    {
                        if (item.isParent == true && item.parentId == 0)
                        {
                            <li>
                                <a href="#"><i class="@item.imageClass"></i> @item.nameOption<span class="fa arrow"></span></a>                          
                                <ul class="nav nav-second-level">
                                    @foreach (var child in Model.Where(p => p.parentId == item.Id))
                                    {
                                        if (child.controller == null)
                                        {
                                            <li><a href="#">@child.nameOption</a></li>
                                        }
                                        else
                                        {
                                            if (child.isParent == true)
                                            {
                                                <li>
                                                    <a href="@Url.Action(child.action, child.controller)"><i class="@child.imageClass"></i> @child.nameOption<span class="fa arrow"></span></a>
                                                    <ul class="nav nav-third-level">
                                                        @foreach (var childInside in Model.Where(p => p.parentId == child.Id))
                                                        {
                                                            if (childInside.controller == null)
                                                            {
                                                                <li><a href="#">@childInside.nameOption</a></li>
                                                            }
                                                            else
                                                            {
                                                                <li><a href="@Url.Action(child.action, child.controller)">@childInside.nameOption</a></li>
                                                            }
                                                        }
                                                    </ul>
                                                </li>
                                            }
                                            else
                                            {
                                                <li><a href="@Url.Action(child.action, child.controller)">@child.nameOption</a></li>
                                            }
                                        }
                                    }
                                </ul>                                                                                            
                            </li>
                        }              
                    }
                }
