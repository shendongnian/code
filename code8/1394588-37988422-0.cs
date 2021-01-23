    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Shapes;
    using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
    
    namespace RCFramework
    {
        public class polyline_property
        {
            private Polyline drawobj;
            private BindingList<custom_point> point_collection;
    
            public polyline_property(Polyline obj)
            {
                drawobj = obj;
    
                point_collection = new BindingList<custom_point>();
                point_collection.AllowEdit = true;
                point_collection.AllowNew = true;
                point_collection.AllowRemove = true;
    
                foreach (Point pnt in drawobj.Points)
                {
                    custom_point newpnt = new custom_point();
                    newpnt.X = pnt.X;
                    newpnt.Y = pnt.Y;
                    point_collection.Add(newpnt);
                }
    
                point_collection.RaiseListChangedEvents = true;
                point_collection.ListChanged += point_collection_ListChanged;
            }
    
            private void point_collection_ListChanged(object sender, ListChangedEventArgs e)
            {
                PointCollection pcol = new PointCollection();
                foreach (custom_point pnt in point_collection)
                {
                    pcol.Add(new Point(pnt.X, pnt.Y));
                }
                drawobj.Points = pcol;
            }
    
    
            public BindingList<custom_point> Points
            {
                get
                {
                    point_collection.RaiseListChangedEvents = false;
                    point_collection.Clear();
                    foreach (Point pnt in drawobj.Points)
                    {
                        custom_point newpnt = new custom_point();
                        newpnt.X = pnt.X;
                        newpnt.Y = pnt.Y;
                        point_collection.Add(newpnt);
                    }
                    point_collection.RaiseListChangedEvents = true;
                    return point_collection;
                }
                set
                {
    
                }
            }
    
            public Color Color
            {
                get
                {
                    return ((SolidColorBrush)drawobj.Stroke).Color;
                }
                set
                {
                    ((SolidColorBrush)drawobj.Stroke).Color = value;
                }
            }
    
            public Double StrokeThickness
            {
                get
                {
                    return drawobj.StrokeThickness;
                }
                set
                {
                    drawobj.StrokeThickness = value;
                }
            }
    
            public DoubleCollection StrokeDashArray
            {
                get
                {
                    return drawobj.StrokeDashArray;
                }
                set
                {
                    drawobj.StrokeDashArray = value;
                }
            }
    
            public PenLineCap StrokeDashCap
            {
                get
                {
                    return drawobj.StrokeDashCap;
                }
                set
                {
                    drawobj.StrokeDashCap = value;
                }
            }
    
            public Double StrokeDashOffset
            {
                get
                {
                    return drawobj.StrokeDashOffset;
                }
                set
                {
                    drawobj.StrokeDashOffset = value;
                }
            }
        }
    
        public class custom_point
        {
            public Double X { get; set; }
            public Double Y { get; set; }
    
            public custom_point()
            {
    
            }
        }
    }
