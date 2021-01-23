    using System.Collections.Generic;
    using System.Linq;
    using App.Data.Entities;
    using App.Business.Models;
    
    namespace App.Business
    {
        public static partial class OverviewAdapter
        {
            public static OverviewViewModel ToOverviewViewModel(this Overview overview)
            {
                return new OverviewViewModel
                {
                    chain_name                  =   overview.chain_name,
                    store_id                    =   overview.store_id,
                    total_attempts              =   overview.total_attempts,
                    total_unique_number_called  =   overview.total_unique_number_called,
                    total_callable              =   overview.total_callable,
                    total_completed_interviews  =   overview.total_completed_interviews,
                    unique_number_per_complete  =   0
                };
            }
    
            public static IEnumerable<OverviewViewModel> ToOverviewModelList(this IEnumerable<OverviewViewModel> overviewList)
            {
                return (overviewList != null) ? overviewList.Select(a => a.ToOverviewViewModel()) : new List<OverviewViewModel>();
            }
    
            // Reverse - ToOverview / ToOverviewList if needed...
       }
    }
