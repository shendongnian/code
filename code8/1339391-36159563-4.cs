    public class BuildingExpenseCalculator
    {
        private readonly IAccount _account;
        private readonly float _moneyNeeded;
        private readonly float _spendingRate;
        private float _moneyNeededRemaining;
        private DateTime _lastSubtract;
        public BuildingExpenseCalculator(IAccount account, float moneyNeeded, TimeSpan timeNeeded)
        {
            _account = account;
            _moneyNeeded = moneyNeeded;
            _spendingRate = moneyNeeded/(float) timeNeeded.TotalSeconds;
        }
        
        public void StartCalculation()
        {
            _lastSubtract = DateTime.Now;
            _moneyNeededRemaining = _moneyNeeded;
        }
        public float GetValueToSubtract()
        {
            var now = DateTime.Now;
            var timePassedSinceLastSubtract = now - _lastSubtract;
            var moneyToSubtractSinceLast = (float)(_spendingRate*timePassedSinceLastSubtract.TotalSeconds);
            // Ensure we do not exceed the remaining money that is needed.
            moneyToSubtractSinceLast = Math.Min(moneyToSubtractSinceLast, _moneyNeededRemaining);
            // Ensure we do not spent more money than is available in the account.
            moneyToSubtractSinceLast = Math.Min(moneyToSubtractSinceLast, _account.AvailableMoney);
            // Update for next iteration.
            _moneyNeededRemaining -= moneyToSubtractSinceLast;
            _lastSubtract = now;
            return moneyToSubtractSinceLast;
        }
    }
    public interface IAccount
    {
        float AvailableMoney { get; set; }        
    }
