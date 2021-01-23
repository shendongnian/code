            // Expect only Twelve bus
            var result = LinqTestMethod.FilterBuses("Twelve", Status.ON);
            // Expect no buses
            result = LinqTestMethod.FilterBuses("Twelve", Status.OFF);
            // Expect 2 buses -- Twelve and Twenty
            result = LinqTestMethod.FilterBuses("T", Status.OFF);
