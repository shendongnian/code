        /// <summary> 
        /// DependencyProperty for <see cref="FontFamily" /> property.
        /// </summary>
        [CommonDependencyProperty]
        public static readonly DependencyProperty FontFamilyProperty = 
                TextElement.FontFamilyProperty.AddOwner(typeof(TextBlock));
 
        /// <summary> 
        /// The FontFamily property specifies the name of font family.
        /// </summary> 
        [Localizability(LocalizationCategory.Font)]
        public FontFamily FontFamily
        {
            get { return (FontFamily) GetValue(FontFamilyProperty); } 
            set { SetValue(FontFamilyProperty, value); }
        } 
 
        /// <summary>
        /// DependencyProperty setter for <see cref="FontFamily" /> property. 
        /// </summary>
        /// <param name="element">The element to which to write the attached property.</param>
        /// <param name="value">The property value to set</param>
        public static void SetFontFamily(DependencyObject element, FontFamily value) 
        {
            if (element == null) 
            { 
                throw new ArgumentNullException("element");
            } 
            element.SetValue(FontFamilyProperty, value);
        }
 
        /// <summary>
        /// DependencyProperty getter for <see cref="FontFamily" /> property. 
        /// </summary> 
        /// <param name="element">The element from which to read the attached property.</param>
        public static FontFamily GetFontFamily(DependencyObject element) 
        {
            if (element == null)
            {
                throw new ArgumentNullException("element"); 
            }
 
            return (FontFamily)element.GetValue(FontFamilyProperty); 
        }
