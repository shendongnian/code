    var Printer = Context.Printer.Join(Context.Resolution, p => p.PrinterID, r => r.PrinterId, (p, r) => new
            {
                PrinterId = p.PrinterID,
                Name=p.Name,
                Description=p.Description,
                Resolution = String.Join(", ", resolutions.Where(k => k.PrinterId == p.PrinterID).Select(lm => lm.Measure.ToString()))
            }).Distinct();
