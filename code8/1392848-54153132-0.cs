    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    
    namespace MyApp.Extensions
    {
        public static class IApplicationBuilderExtensions
        {
            public static void SyncMigrations<T>(this IApplicationBuilder app) where T : DbContext
            {
                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var context = serviceScope.ServiceProvider.GetService<DbContext>();
                    context.Database.Migrate();
                }
            }
        }
    }
