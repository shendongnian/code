    using System;
    using System.Collections.Generic;
    using System.Linq;
    public IList<ActivityEvent> GetActivityEvent(string sESSION_ID)
        {
            var result = this.unitOfWork.Context.GetActivityEvent(sESSION_ID);
            if (result != null)
            {
                return result.ToList();
            }
            return null;  
        }
