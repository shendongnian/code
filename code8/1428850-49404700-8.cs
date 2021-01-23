    class OurViewModel : ViewModelBase
	{
		private int _partOne;
		public int PartOne
		{
			get => _partOne;
			set => SetPropertyValue(ref _partOne, value)
				.WithDependent(nameof(Total));
		}
		private int _partTwo;
		public int PartTwo
		{
			get => _partTwo;
			set => SetPropertyValue(ref _partTwo, value)
				.WithDependent(nameof(Total))
				.WithDependent(nameof(PartTwoPlus2));
		}
		public int Total {
			get => PartOne + PartTwo;
		}
		public int PartTwoPlus2 {
			get => PartTwo + 2;
		}
	}
