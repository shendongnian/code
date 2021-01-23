            var joinedProgramOptions = Programs.AsEnumerable().SelectMany(p =>
            {
                if (p.ProgramOptions.Any())
                {
                    return p.ProgramOptions.Select(po => new { Prog = p, ProgOpt = po });
                }
                int[] dummy = new int[] { 0 };
                return dummy.Select(d => {
                    return new { Prog = p, ProgOpt = p.ProgramOptions.FirstOrDefault() };
                });
            });
            joinedProgramOptions = joinedProgramOptions
                .OrderBy(jq => jq.ProgOpt?.Name ?? jq.Prog.Name)
                .Skip(cardsStartIndex ?? 0)
                .Take(15);
            List<ProgramViewModel> cards = joinedProgramOptions.Select(hybridObject =>
                new ProgramViewModel()
                {
                    Title = hybridObject.ProgOpt?.Name ?? hybridObject.Prog.Name,
                    OptionOf = hybridObject.ProgOpt?.Program,
                    Degrees = hybridObject.Prog.ProgramDegrees,
                    Departments = hybridObject.Prog.Departments
                }
            ).ToList();
