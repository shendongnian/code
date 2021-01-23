    var result = _schedule.Where(s => s.GroupID == 1)
                          .GroupBy(x => x.GroupID)
                          .Select(gr => new
                          {
                              TotalDays = gr.Count(),
                              TotalHours = gr.Sum(s=>s.Hours);
                          });
