    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Security.Claims;
    using Newtonsoft.Json;
    
    namespace ConsoleApplication2
    {
        public class UserInformation
        {
            public int AccountId { get; set; }
        }
    
        public static class ClaimsIdentityExtensions
        {
            private static readonly ConcurrentDictionary<string, UserInformation> CachedUserInformations = new ConcurrentDictionary<string, UserInformation>();
            public static IEnumerable<UserInformation> GetUserInformationClaims(this ClaimsIdentity identity, bool withConcurrentDictionary)
            {
                if (withConcurrentDictionary)
                {
                    return identity
                        .Claims
                        .Where(c => c.Type == ClaimTypes.UserData)
                        .Select(c => CachedUserInformations.GetOrAdd(
                            c.Value,
                            JsonConvert.DeserializeObject<UserInformation>));
                }
    
                return identity
                    .Claims
                    .Where(c => c.Type == ClaimTypes.UserData)
                    .Select(c => JsonConvert.DeserializeObject<UserInformation>(c.Value));
            }
        }
    
        class Program
        {
            static void Main()
            {
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.UserData, "{AccountId: 1}"),
                    new Claim(ClaimTypes.UserData, "{AccountId: 2}"),
                    new Claim(ClaimTypes.UserData, "{AccountId: 3}"),
                    new Claim(ClaimTypes.UserData, "{AccountId: 4}"),
                    new Claim(ClaimTypes.UserData, "{AccountId: 5}"),
                });
    
                const int iterations = 1000000;
                var stopwatch = Stopwatch.StartNew();
                for (var i = 0; i < iterations; ++i)
                {
                    identity.GetUserInformationClaims(withConcurrentDictionary: true).ToList();
                }
                Console.WriteLine($"With ConcurrentDictionary: {stopwatch.Elapsed}");
    
                stopwatch = Stopwatch.StartNew();
                for (var i = 0; i < iterations; ++i)
                {
                    identity.GetUserInformationClaims(withConcurrentDictionary: false).ToList();
                }
                Console.WriteLine($"Without ConcurrentDictionary: {stopwatch.Elapsed}");
            }
        }
    }
    
