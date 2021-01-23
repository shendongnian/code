    // Get by Filters //
            public String GetAccomFilterPages(Int32 ModelID, Int32 page, String location, String type, String grade, String facility)
            {
                // Builder Start //
                AccommodationList Model = Umbraco.TypedContent(ModelID) as AccommodationList;
                StringBuilder HTMLAccom = new StringBuilder();
    
                //Build list and use | to split //
    
                List<Accommodation> LocationResults = new List<Accommodation>();
                List<Accommodation> TypeResults = new List<Accommodation>();
                List<Accommodation> GradeResults = new List<Accommodation>();
                List<Accommodation> FacResults = new List<Accommodation>();
                List<Accommodation> Results = new List<Accommodation>();
                Boolean noFilter = true;
    
                // Location
                if (!String.IsNullOrEmpty(location))
                {
                    String[] Locations = location.Split('|');
                    foreach (String locSearch in Locations)
                    {
                        if (!String.IsNullOrEmpty(locSearch))
                        {
                            foreach (var locItem in Model.Descendants<Accommodation>().Where(x => x.Location.Where(xx => xx.Name.Replace("&", "and") == locSearch.Replace("&", "and")).Count() > 0))
                            {
                                if (!LocationResults.Contains(locItem))
                                {
                                    LocationResults.Add(locItem);
                                }
                            }
                        }
                    }
                    noFilter = false;
                }
                    // If no filters set to all descendants. Similar Else's work to make sure if a filter isn't used the filtering still works by defaulting to check through all descendants. 
                else
                {
                    LocationResults.AddRange(Model.Descendants<Accommodation>());
                }
    
                // Accom Types
                if (!String.IsNullOrEmpty(type))
                {
                    String[] Types = type.Split('|');
                    foreach (String typSearch in Types)
                    {
                        if (!String.IsNullOrEmpty(typSearch))
                        {
                            foreach (var typItem in LocationResults.Where(x => x.AccommodationType.Where(xx => xx.Name.Replace("&", "and") == typSearch.Replace("&", "and")).Count() > 0))
                            {
                                if (!TypeResults.Contains(typItem))
                                {
                                    TypeResults.Add(typItem);
                                }
                            }
                        }
                    }
                    noFilter = false;
                }
                else
                {
                    TypeResults.AddRange(LocationResults);
                }
    
    
                // Grades
                if (!String.IsNullOrEmpty(grade))
                {
                    String[] Grades = grade.Split('|');
                    foreach (String gradeSearch in Grades)
                    {
                        if (!String.IsNullOrEmpty(gradeSearch))
                        {
                            foreach (var gradeItem in TypeResults.Where(x => x.GradeRating.Where(xx => xx.Name.Replace("&", "and") == gradeSearch.Replace("&", "and")).Count() > 0))
                            {
                                if (!GradeResults.Contains(gradeItem))
                                {
                                    GradeResults.Add(gradeItem);
                                }
                            }
                        }
                    }
                    noFilter = false;
                }
                else
                {
                    GradeResults.AddRange(TypeResults);
                }
    
    
    
                // Facilities
                //For this section we are using a 'for' since we are wanting to remove non-matching results
    
                FacResults.AddRange(GradeResults);
                if (!String.IsNullOrEmpty(facility))
                {
                    String[] Facilities = facility.Split('|');
                    foreach (String facSearch in Facilities)
                    {
                        if (!String.IsNullOrEmpty(facSearch))
                        {
                            for (int i = FacResults.Count - 1; i >= 0; i--)
                            {
                                Accommodation currentAccom = FacResults[i];
                                if (currentAccom.FacilitiesAvaliable.Where(x => x.Name.Replace("&", "and") == facSearch.Replace("&", "and")).Count() == 0)
                                {
                                    FacResults.Remove(currentAccom);
                                }
                            }
                        }
                    }
                    noFilter = false;
                }
    
                if (noFilter == true)
                {
                    Results.AddRange(Model.Descendants<Accommodation>());
                }
                else
                {
                    Results.AddRange(FacResults);            
                }
    
                // End Filtering //
                int skip = 0;
                int take = 5;
                int totalNodes = Results.Count();
                int totalPages = (int)Math.Ceiling((double)totalNodes / take);
    
                // Results Count //
                int lastIdOnPage = take;
    
                if (page != 1)
                {
                    skip = take * (page - 1);
                    lastIdOnPage = (totalNodes - skip);
                    if (lastIdOnPage > take)
                    {
                        lastIdOnPage = skip + take;
                    }
                    else
                    {
                        lastIdOnPage = skip + lastIdOnPage;
                    }
    
                }
                else if (take > totalNodes)
                {
                    lastIdOnPage = totalNodes;
                }
                int firstIdOnPage = skip + 1;
    
                // Start Print of Page //
                // Loop through Accoms //
    
                foreach (Accommodation ACC in Results.Skip(skip).Take(take))
                {
                    ...
                }
    
                // Filter Reset //
                if (noFilter == false)
                {
                    HTMLAccom.AppendLine("<li><a onclick=\"GetAccomPages(1, false)\">Remove Filters</a></li>");
                }
    
                // Pagination Results //
                if (firstIdOnPage == lastIdOnPage)
                {
                    HTMLAccom.AppendLine("<p>" + firstIdOnPage + " of " + totalNodes + " results</p>");
                }
                else if (lastIdOnPage == 0)
                {
                    HTMLAccom.AppendLine("<p> No results</p>");
                }
                else
                {
                    HTMLAccom.AppendLine("<p>" + firstIdOnPage + " - " + lastIdOnPage + " of " + totalNodes + " results</p>");
                }
    
                // Page Links //
                if (totalPages > 1)
                {
                    int countPages = 0;
                    HTMLAccom.AppendLine("<ul class=\"pagination\">");
                    while (totalPages > countPages)
                    {
                        countPages++;
                        HTMLAccom.AppendLine("<li " + (countPages == page ? "class=\"active\">" : "") + "<a onclick=\"GetAccomFilterPages(" + (countPages) + ")\">" + countPages + "</a></li>");
                    }
                    HTMLAccom.AppendLine("</ul>");
                }
    
                return HTMLAccom.ToString();
            }
