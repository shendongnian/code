                var framing = from c in frameStart
                              join e in frameEnd on new { c.CustomerID, c.SubdivisionID, c.LotNumber } equals new { e.CustomerID, e.SubdivisionID, e.LotNumber } into jointable
                              from z in jointable.DefaultIfEmpty()
                              select new s84_Report_FrameLabor
                              {
                                  CustomerID = c.CustomerID,
                                  CustomerName = c.CustomerName,
                                  SubdivisionID = c.SubdivisionID,
                                  SubdivisionName = c.SubdivisionName,
                                  LotNumber = c.LotNumber,
                                  FrameLaborStart = c.FrameLaborStart,
                                  FrameLaborComplete = z.FrameLaborComplete,
                                  Duration = c.FrameLaborStart == null ? z.FrameLaborComplete == null ? (z.FrameLaborComplete - c.FrameLaborStart).Days : 0 : 0
                              };
                return framing.ToList();
