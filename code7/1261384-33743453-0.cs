     lock (ctx)
                {
                    if ((bool)ctx.Entry(x).Property("DayLock").CurrentValue == false)
                    {
                        ctx.SaveChanges();
                    }
                }
