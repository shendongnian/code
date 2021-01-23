    using System;
    using System.Linq.Expressions;
    using System.Windows.Forms;
    
    namespace Samples
    {
    	public static class ListBoxUtils
    	{
    		public static void UpdateHorizontalScrollbar(this ListBox target)
    		{
    			updateHorizontalScrollbarFunc(target);
    		}
    		private static readonly Action<ListBox> updateHorizontalScrollbarFunc = CreateUpdateScrollbarFunc();
    		private static Action<ListBox> CreateUpdateScrollbarFunc()
    		{
    			var target = Expression.Parameter(typeof(ListBox), "target");
    			var body = Expression.Block(
    				Expression.Assign(Expression.Field(target, "maxWidth"), Expression.Constant(-1)),
    				Expression.Call(target, "UpdateHorizontalExtent", null)
    			);
    			var lambda = Expression.Lambda<Action<ListBox>>(body, target);
    			return lambda.Compile();
    		}
    	}
    }
