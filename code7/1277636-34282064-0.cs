         private IQueryable SortXpr(IQueryable<EmailAflAwmMessageDM> email ,string sort,string dir) {
    
            if (sort.Contains("to"))
            {
                if (dir.Contains("asc"))
                {
                    return email.OrderBy(e => e.to_msg);
                }
                else
                {
                    return email.OrderByDescending(e => e.to_msg);
                }
            }
            else if (sort.Contains("from"))
            {
                if (dir.Contains("asc"))
                {
                    return email.OrderBy(e => e.from_msg);
                }
                else
                {
                    return email.OrderByDescending(e => e.from_msg);
                }
            }
            else if (sort.Contains("subject"))
            {
                if (dir.Contains("asc"))
                {
                    return email.OrderBy(e => e.subject);
                }
                else
                {
                    return email.OrderByDescending(e => e.subject);
                }
            }
            else
            {
                if (dir.Contains("asc"))
                {
                    return email.OrderBy(e => e.msg_date);
                }
                else
                {
                    return email.OrderByDescending(e => e.msg_date);
                }
            }
        
        }
