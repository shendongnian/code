    using System.Collections.Generic;
    interface IEvaluation {
        void StartEvaluation();
    }
    class LocationEvaluation : IEvaluation {
        public void StartEvaluation() {
            // do something...
        }
    }
    class AssetEvaluation : IEvaluation {
        public void StartEvaluation() {
            // do something...
        }
    }
    class Program {
        static void Main(string[] args) {
            // fill dictionary with IEvaluation objects
            Dictionary<string, IEvaluation> evaluations = new Dictionary<string, IEvaluation>();
            evaluations["LocationEvaluation"] = new LocationEvaluation();
            evaluations["AssetEvaluation"] = new AssetEvaluation();
            // get an object from the dictionary and call the function on it
            IEvaluation evaluation = evaluations["AssetEvaluation"];
            evaluation.StartEvaluation();
        }
    }
 
