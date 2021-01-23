    using System;
    using System.CodeDom;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
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
    				me.ResetWithNewEnum(dependencyPropertyChangedEventArgs.NewValue);
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
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace WpfContextMenuWithEnum
    {
    	public class EnumWrapperIteratorAndSelectorChoice : INotifyPropertyChanged
    	{
    		public event PropertyChangedEventHandler PropertyChanged;
    
    		private EnumWrapperIteratorAndSelector _enumWrapperIteratorAndSelectorChoice;
    		public Enum EnumValueRef { get; private set; }
    		public string Name { get; set; }
    		public string Description { get; set; }
    
    		public bool IsChecked
    		{
    			get
    			{
    				return _enumWrapperIteratorAndSelectorChoice.Enum.Equals(EnumValueRef);
    			}
    
    			set
    			{
    				if (value) // Can only set value
    				{
    					_enumWrapperIteratorAndSelectorChoice.Enum = EnumValueRef;
    				}
    			}
    		}
    
    		public EnumWrapperIteratorAndSelectorChoice(EnumWrapperIteratorAndSelector enumWrapperIteratorAndSelectorChoice, 
    			Enum enumValueRef, string description = null)
    		{
    			_enumWrapperIteratorAndSelectorChoice = enumWrapperIteratorAndSelectorChoice;
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
