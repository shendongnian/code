    using System;
    using System.Diagnostics.Eventing.Reader;
    using System.Globalization;
    public static class Program {
        static void Main(string[] args) {
            foreach (var providerName in EventLogSession.GlobalSession.GetProviderNames()) {
                DumpMetadata(providerName);
            }
        }
        private static void DumpMetadata(string providerName) {
            try {
                ProviderMetadata providerMetadata = new ProviderMetadata(providerName, EventLogSession.GlobalSession, CultureInfo.InvariantCulture);
                foreach (var eventMetadata in providerMetadata.Events) {
                    if (!string.IsNullOrEmpty(eventMetadata.Description)) {
                        Console.WriteLine("{0} ({1}): {2}", eventMetadata.Id, eventMetadata.Version, eventMetadata.Description);
                    }
                }
            } catch (EventLogException) {
                Console.WriteLine("Cannot read metadata for provider {0}", providerName);
            } 
        }
    }
