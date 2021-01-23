    using Gma.QrCodeNet.Encoding;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace WpfApp1
    {
        /// <summary>
        /// Interaction logic for QRCode.xaml
        /// </summary>
        public partial class QRCode : UserControl, INotifyPropertyChanged
        {
            public QRCode()
            {
                InitializeComponent();
    
                //default point size
                this.Size = 3;
                qrcodeControl.ItemsSource = QRMatrix;
            }
    
            private ObservableCollection<ObservableCollection<QrCodePoint>> qrMatrix = new ObservableCollection<ObservableCollection<QrCodePoint>>();
            ObservableCollection<ObservableCollection<QrCodePoint>> QRMatrix
            {
                get
                {
                    return this.qrMatrix;
                }
            }
    
            public new static readonly DependencyProperty ContentProperty = DependencyProperty.Register(
                "Content",
                typeof(string),
                typeof(QRCode),
                new UIPropertyMetadata((s, e) =>
                {
                    QRCode dp = s as QRCode;
                    dp.QRMatrix.Clear();
                    dp.Generate(e.NewValue.ToString()).ForEach(
                        line =>
                        {
                            ObservableCollection<QrCodePoint> linePoints = new ObservableCollection<QrCodePoint>();
                            dp.qrMatrix.Add(linePoints);
                            foreach (var point in line)
                            {
                                linePoints.Add(point);
                            }
                        });
                    dp.RaisePropertyChanged("Content");
                }));
    
            public new string Content
            {
                get { return (string)GetValue(ContentProperty); }
                set { SetValue(ContentProperty, value); }
            }
    
            public static readonly DependencyProperty SizeProperty = DependencyProperty.Register(
                "Size",
                typeof(double),
                typeof(QRCode),
                new UIPropertyMetadata((s, e) =>
                {
                    QRCode dp = s as QRCode;
                    dp.RaisePropertyChanged("Size");
                }));
    
            public double Size
            {
                get { return (double)GetValue(SizeProperty); }
                set { SetValue(SizeProperty, value); }
            }
    
            public List<QrCodePoint[]> Generate(string content)
            {
                List<QrCodePoint[]> result = new List<QrCodePoint[]>();
                QrEncoder encoder = new QrEncoder(ErrorCorrectionLevel.M);
                QrCode qrCode;
                encoder.TryEncode(content, out qrCode);
    
                for (int i = 0; i < qrCode.Matrix.Height; i++)
                {
                    var line = new QrCodePoint[qrCode.Matrix.Width];
                    result.Add(line);
                    for (int j = 0; j < qrCode.Matrix.Width; j++)
                    {
                        line[j] = new QrCodePoint() { Color = qrCode.Matrix[i, j] ? Brushes.Black : Brushes.White, Size = this.Size };
                    }
                }
    
                return result;
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            public void RaisePropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
