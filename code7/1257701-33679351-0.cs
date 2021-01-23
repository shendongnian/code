    UserData.InnovateSection = new List<DropDownList>{new DropDownList { label = "Health", value = "Creating a world wide network, bringing people together by not having any distinction by race, caste or religion?" },
                            new DropDownList { label = "Health", value = "Tracking down loved one's in a crowded or emergency situation at a cost effective manner?" },
                            new DropDownList { label = "Social Service", value = "Others" }};
                    var headers = (from it in UserData.InnovateSection
                                   select it.label).Distinct().ToList();
                    var headersLength = headers.Count;
                    int i = 0, k;
                    UserData.Innovate = new System.Text.StringBuilder();
                    while (i < headersLength)
                    {
                        k = 0;
                        foreach (var item in UserData.InnovateSection)
                        {
                            if (headers[i] == item.label && k == 0)
                            {
                                UserData.Innovate.Append("<optgroup label = " + "\"" + item.label + "\"" + ">");
                                k = 1;
                            }
                            if (headers[i] == item.label)
                            {
                                UserData.Innovate.Append("<option value= " + "\"" + item.value + "\"" + ">" + item.value + "</option>");
                            }
         
                        }
                       
                        UserData.Innovate.Append("</optgroup>");
                        i++;
                    }
                    return View(UserData);
        
