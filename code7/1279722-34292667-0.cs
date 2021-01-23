    public static class CarExtensionMethods {
        public static string TextFileString(this Car car) {
            return string.format("{0}|{1}|{2}", car.Make, car.Model, car.Year);
        }
    }
