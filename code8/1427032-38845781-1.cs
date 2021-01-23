    rusing System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    namespace Test
    {
        public class TriangularButton : Button
        {
            public static readonly DependencyProperty AngleProperty = DependencyProperty.Register(
            "Angle",
            typeof(float),
            typeof(TriangularButton),
            new FrameworkPropertyMetadata(0f, FrameworkPropertyMetadataOptions.AffectsRender));
        public float Angle
        {
            get { return (float)GetValue(AngleProperty); }
            set { SetValue(AngleProperty, value); }
        }
    }
