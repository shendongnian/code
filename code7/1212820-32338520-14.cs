        using System;
        using System.Collections;
        using System.Collections.Generic;
        using System.Collections.ObjectModel;
        using System.Collections.Specialized;
        using System.ComponentModel;
        using System.Reflection;
        using System.Windows;
        
        namespace WpfContextMenuWithEnum
        {
        	/// <summary>
        	/// Note: Freezable is necessary otherwise binding will never occurs if EnumWrapperIteratorAndSelector is defined
        	/// as resources. See article for more info: 
        	/// http://www.thomaslevesque.com/2011/03/21/wpf-how-to-bind-to-data-when-the-datacontext-is-not-inherited/
        	///  </summary>
        	public class EnumWrapperIteratorAndSelector : Freezable, IEnumerable<EnumWrapperIteratorAndSelectorChoice>, INotifyCollectionChanged
        	{
        		// ******************************************************************
        		public static readonly DependencyProperty EnumProperty =
        			DependencyProperty.Register("Enum", typeof(Enum), typeof(EnumWrapperIteratorAndSelector), new PropertyMetadata(null, PropertyChangedCallback));
        
        		ObservableCollection<EnumWrapperIteratorAndSelectorChoice> _allEnumValue = new ObservableCollection<EnumWrapperIteratorAndSelectorChoice>();
        
        		// ******************************************************************
        		private static void PropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        		{
        			if (!(dependencyPropertyChangedEventArgs.NewValue is Enum))
        			{
        				throw new ArgumentException("Only enum are supported.");
        			}
        
        			var me = dependencyObject as EnumWrapperIteratorAndSelector;
        			if (me != null)
        			{
        				if (dependencyPropertyChangedEventArgs.OldValue == null)
        				{
        					me.ResetWithNewEnum(dependencyPropertyChangedEventArgs.NewValue);
        				}
        				else
        				{
        					foreach(EnumWrapperIteratorAndSelectorChoice enumWrapperIteratorAndSelectorChoice in me._allEnumValue)
        					{
        						enumWrapperIteratorAndSelectorChoice.RaiseChangeIfAppropriate(dependencyPropertyChangedEventArgs);
        					}
        				}
        			}
        		}
        
        		// ******************************************************************
        		private void ResetWithNewEnum(object enumValue)
        		{
        			_allEnumValue.Clear();
        
        			var enumType = Enum.GetType();
        			foreach (Enum enumValueIter in Enum.GetValues(enumValue.GetType()))
        			{
        				MemberInfo[] memberInfos = enumType.GetMember(enumValueIter.ToString());
        				if (memberInfos.Length > 0)
        				{
        					var desc = memberInfos[0].GetCustomAttribute<DescriptionAttribute>();
        					if (desc != null)
        					{
        						_allEnumValue.Add(new EnumWrapperIteratorAndSelectorChoice(this, enumValueIter, desc.Description));
        					}
        					else
        					{
        						_allEnumValue.Add(new EnumWrapperIteratorAndSelectorChoice(this, enumValueIter));
        					}
        				}
        			}
        		}
        
        		// ******************************************************************
        		public Enum Enum
        		{
        			get { return (Enum)GetValue(EnumProperty); }
        			set
        			{
        				SetValue(EnumProperty, value);
        			}
        		}
        
        		// ******************************************************************
        		internal void SetCurrentValue(Enum enumValue)
        		{
        			SetCurrentValue(EnumProperty, enumValue);
        		}
        		
        		// ******************************************************************
        		public IEnumerator GetEnumerator()
        		{
        			return _allEnumValue.GetEnumerator();
        		}
        
        		// ******************************************************************
        		IEnumerator<EnumWrapperIteratorAndSelectorChoice> IEnumerable<EnumWrapperIteratorAndSelectorChoice>.GetEnumerator()
        		{
        			return _allEnumValue.GetEnumerator();
        		}
        
        		// ******************************************************************
        		public event NotifyCollectionChangedEventHandler CollectionChanged
        		{
        			add { _allEnumValue.CollectionChanged += value; }
        			remove { _allEnumValue.CollectionChanged -= value; }
        		}
        
        		// ******************************************************************
        		protected override Freezable CreateInstanceCore()
        		{
        			return new EnumWrapperIteratorAndSelector();
        		}
        
        		// ******************************************************************
        
        	}
        }
        
        using System;
        using System.ComponentModel;
        using System.Windows;
        
        namespace WpfContextMenuWithEnum
        {
        	public class EnumWrapperIteratorAndSelectorChoice : INotifyPropertyChanged
        	{
        		public event PropertyChangedEventHandler PropertyChanged;
        
        		private EnumWrapperIteratorAndSelector _enumWrapperIteratorAndSelector;
        		public Enum EnumValueRef { get; private set; }
        		public string Name { get; set; }
        		public string Description { get; set; }
        
        		public bool IsChecked
        		{
        			get
        			{
        				return _enumWrapperIteratorAndSelector.Enum.Equals(EnumValueRef);
        			}
        
        			set
        			{
        				if (value) // Can only set value
        				{
        					_enumWrapperIteratorAndSelector.SetCurrentValue(EnumValueRef);
        				}
        			}
        		}
        
        		internal void RaiseChangeIfAppropriate(DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        		{
        			if (EnumValueRef.Equals(dependencyPropertyChangedEventArgs.OldValue) ||
        				EnumValueRef.Equals(dependencyPropertyChangedEventArgs.NewValue))
        			{
        				var propertyChangeLocal = PropertyChanged;
        				if (propertyChangeLocal != null)
        				{
        					propertyChangeLocal(this, new PropertyChangedEventArgs("IsChecked"));
        				}
        			}
        		}
        
        		public EnumWrapperIteratorAndSelectorChoice(EnumWrapperIteratorAndSelector enumWrapperIteratorAndSelector,
        			Enum enumValueRef, string description = null)
        		{
        			_enumWrapperIteratorAndSelector = enumWrapperIteratorAndSelector;
        			EnumValueRef = enumValueRef;
        			Name = enumValueRef.ToString();
        			Description = description;
        		}
        
        		public string DisplayName
        		{
        			get { return Description ?? Name; }
        		}
        	}
        }
    
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.CommandWpf;
    
    namespace WpfContextMenuWithEnum
    {
    	public class MainWindowModel : ViewModelBase
    	{
    		private EnumChoice _selectedEnumChoice;
    
    		public EnumChoice SelectedEnumChoice
    		{
    			get { return _selectedEnumChoice; }
    			set { _selectedEnumChoice = value; RaisePropertyChanged(); }
    		}
    	}
    }
