    Proposals.OrderByDescending (p => p.ID)
      .First ()
      .Proposal_ProductConfigurations
      .Where(ppc => ppc.ProductConfigurationHistory.Active
                    && ppc.ProductConfigurationHistory.ProductConfiguration.Active)
      .SelectMany(
        ppc => ppc.ProductConfigurationHistory
                  .ProductConfiguration
                  .ProductConfigurations_PriceBookEntries,
        (ppc, pcpb) => new { ppc, pcpb })
      .Where(anon => anon.pcpb.Active)
      .OrderBy(anon => anon.pcpb.PriceBook.ProductCode)
      .GroupBy(anon => anon.pcpb.PriceBook.ID)
      .Select (grp => new {
        Code = grp.First().pcpb.PriceBook.ProductCode,
        Description = grp.First().pcpb.PriceBook.Description,
        Quantity = grp.Sum(anon => (anon.pcpb.Quantity ?? 0) * anon.ppc.Quantity),
      })
