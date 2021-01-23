    public class OrderLine : INotifyPropertyChanged {
		decimal qty;
		decimal cost;
		public decimal Qty {
			get { return qty; }
			set { SetNotify(ref qty, value, "Qty", "CostExt"); }
		}
		public decimal Cost {
			get { return cost; }
			set { SetNotify(ref cost, value, "Cost", "CostExt"); }
		}
		public decimal CostExt {
			get {
				return Qty * Cost;
			}
		}
		protected void SetNotify<T>(ref T property, T value, params string[] notificationProperties) {
			var method = PropertyChanged;
			if (method != null) {
				foreach (var p in notificationProperties) {
					method(this, new PropertyChangedEventArgs(p));
				}
			}
		}
		public event PropertyChangedEventHandler PropertyChanged;
	}
