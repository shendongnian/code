    /// <summary>
    /// Provides a wrapper for objects that need to have their selected state checked.
    /// </summary>
    /// <typeparam name="T">The Type you are wrapping</typeparam>
    public class SelectedItemViewModel<T> : ViewModel where T : class
    {
        /// <summary>
        /// The item
        /// </summary>
        private readonly T item;
        /// <summary>
        /// The selected value of Item
        /// </summary>
        private bool isSelected;
        /// <summary>
        /// Initializes a new instance of the <see cref="SelectedItemViewModel{T}" /> class.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="eventService">The event service.</param>
        /// <param name="initialSelectedState">if set to <c>true</c> [initial selected state].</param>
        public SelectedItemViewModel(T item, bool initialSelectedState = false)
        {
            this.item = item;
            this.isSelected = initialSelectedState;
            this.eventService = eventService;
        }
        /// <summary>
        /// Gets the item.
        /// </summary>
        public T Item
        {
            get
            {
                return this.item;
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is selected.
        /// </summary>
        public bool IsSelected
        {
            get
            {
                return this.isSelected;
            }
            set
            {
                this.isSelected = value;
                this.OnPropertyChanged();
            }
        }
    }
