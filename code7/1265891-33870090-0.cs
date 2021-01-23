    namespace JamSoft.CALDemo.Modules.SkinManager
    {
        using System;
        using System.Collections.Generic;
        using System.Collections.ObjectModel;
        using System.Linq;
        using System.Windows;
    
        using JamSoft.CALDemo.Modules.SkinManager.Core;
        using JamSoft.CALDemo.Modules.SkinManager.Core.Exceptions;
    
        /// <summary>
        /// The skin manager class
        /// </summary>
        public class SkinManager : DependencyObject, ISkinManager
        {
            /// <summary>
            /// The current skin property
            /// </summary>
            public static readonly DependencyProperty CurrentSkinProperty = DependencyProperty.Register(
                "CurrentSkin", 
                typeof(Skin), 
                typeof(SkinManager), 
                new UIPropertyMetadata(Skin.Null, OnCurrentSkinChanged, OnCoerceSkinValue));
    
            /// <summary>The default skin name</summary>
            private const string DefaultSkinName = "Default";
    
            /// <summary>The _skin finder</summary>
            private readonly SkinsFinder _skinFinder = new SkinsFinder();
    
            /// <summary>The _skins</summary>
            private List<Skin> _skins = new List<Skin>();
    
            /// <summary>
            /// Initializes a new instance of the <see cref="SkinManager"/> class.
            /// </summary>
            public SkinManager()
            {
                Initialize();
            }
    
            /// <summary>Gets the skins.</summary>
            /// <value>The skins.</value>
            public ObservableCollection<Skin> Skins
            {
                get
                {
                    return new ObservableCollection<Skin>(_skins);
                }
            }
    
            /// <summary>Gets or sets the current skin.</summary>
            /// <value>The current skin.</value>
            public Skin CurrentSkin
            {
                get
                {
                    return (Skin)GetValue(CurrentSkinProperty);
                }
    
                set
                {
                    SetValue(CurrentSkinProperty, value);
                }
            }
    
            /// <summary>Loads the specified skin or the default if specified skin isn't found.</summary>
            /// <param name="skinName">Name of the skin.</param>
            public void LoadSkin(string skinName)
            {
                var skin = _skins.FirstOrDefault(x => x.Name.Equals(skinName)) ?? _skins.FirstOrDefault(x => x.Name == DefaultSkinName);
                CurrentSkin = skin;
            }
    
            /// <summary>
            /// Called when [coerce skin value].
            /// </summary>
            /// <param name="d">The <paramref name="d"/>.</param>
            /// <param name="baseValue">The base value.</param>
            /// <returns>the coerced skin <see langword="object"/></returns>
            private static object OnCoerceSkinValue(DependencyObject d, object baseValue)
            {
                if (baseValue == null)
                {
                    return Skin.Null;
                }
    
                return baseValue;
            }
    
            /// <summary>
            /// Called when [current skin changed].
            /// </summary>
            /// <param name="d">The <paramref name="d"/>.</param>
            /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
            private static void OnCurrentSkinChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                try
                {
                    Skin oldSkin = e.OldValue as Skin;
                    oldSkin.Unload();
                    Skin newSkin = e.NewValue as Skin;
                    newSkin.Load();
                }
                catch (SkinException ex)
                {
                    Console.WriteLine(ex);
                }
            }
    
            /// <summary>Initializes <c>this</c> instance.</summary>
            private void Initialize()
            {
                _skinFinder.Initialize();
                _skins = _skinFinder.SkinsList;
            }
        }
    }
