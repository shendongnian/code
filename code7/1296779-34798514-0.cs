    /// <summary>
    /// Defines the mode in which the DragCanvas will act
    /// if set to NoDragging will act a simple Canvas
    /// if set to AllowDragInView Dragging is enabled but no Draging out of Canvas view is allowed,
    /// elements will not get out of DragCanvas borders
    /// if set to AllowDragOutOfView dragging is enabled and elements may be dragged out of the
    /// DragCanvas borders
    /// </summary>
    public enum DraggingModes
    {
        NoDragging,
        AllowDragInView,
        AllowDragOutOfView
    }
    /// <summary>
    /// Defines to the DragCanvas Relative to which edges of it the element may be repositioned
    /// </summary>
    internal enum ModificationDirection
    {
        None                = 0,
        Left                = 1,
        Right               = 2,
        LeftRight           = 3,
        Top                 = 4,
        LeftTop             = 5,
        RightTop            = 6,
        LeftRightTop        = 7,
        Bottom              = 8,
        LeftBottom          = 9,
        RightBottom         = 10,
        LeftRightBottom     = 11,
        TopBottom           = 12,
        LeftTopBottom       = 13,
        RightTopBottom      = 14,
        LeftRightTopBottom  = 15
    }
    /// <summary>
    /// A Canvas which manages dragging of the UIElements it contains.  
    /// </summary>
    public class DragCanvas : Canvas
    {
    #region Data
    // Keeps track of where the mouse cursor was when a drag operation began.		
    private Point m_InitialCursorLocation;
    // The offsets from the DragCanvas' edges when the drag operation began.
    private double m_OriginalLefOffset;
    private double m_OriginalRightOffset;
    private double m_OriginalTopOffset;
    private double m_OriginalBottomOffset;
    // Keeps track of which horizontal and vertical offset should be modified for the drag element.
    private ModificationDirection m_ModificationDirection;
    // True if a drag operation is underway, else false.
    private bool m_IsDragInProgress;
    #endregion // Data
    #region Properties
    /// <summary>
    /// Gets/sets whether elements in the DragCanvas should be draggable by the user.
    /// The default value is AllowDragInView.
    /// </summary>
    private DraggingModes m_DraggingMode;
    public DraggingModes DraggingMode
    {
        get { return m_DraggingMode; }
        set { m_DraggingMode = value; }
    }
    public static readonly DependencyProperty Draggable;
    public static bool GetCanBeDragged(UIElement uiElement)
    {
        if (uiElement == null)
            return false;
        return (bool)uiElement.GetValue(Draggable);
    }
    public static void SetCanBeDragged(UIElement uiElement, bool value)
    {
        if (uiElement != null)
            uiElement.SetValue(Draggable, value);
    }
    // Stores a reference to the UIElement currently being dragged by the user.
    private UIElement m_DraggedElement;
    /// <summary>
    /// Returns the UIElement currently being dragged, or null.
    /// </summary>
    /// <remarks>
    /// Note to inheritors: This property exposes a protected 
    /// setter which should be used to modify the drag element.
    /// </remarks>
    public UIElement DraggedElement
    {
        get
        {
            if (m_DraggingMode == DraggingModes.NoDragging)
                return null;
            else
                return this.m_DraggedElement;
        }
        protected set
        {
            if (this.m_DraggedElement != null)
            {
                this.m_DraggedElement.ReleaseMouseCapture();
            }
            if (m_DraggingMode == DraggingModes.NoDragging)
            {
                this.m_DraggedElement = null;
            }
            else
            {
                if (DragCanvas.GetCanBeDragged(value))
                {
                    this.m_DraggedElement = value;
                    this.m_DraggedElement.CaptureMouse();
                }
                else
                    this.m_DraggedElement = null;
            }
        }
    }
    #endregion Properties // Properties
    #region Constructor
    /// <summary>
    /// Initializes a new instance of DragCanvas.  UIElements in
    /// the DragCanvas will immediately be draggable by the user.
    /// </summary>
    public DragCanvas()
    {
        m_DraggingMode = DraggingModes.AllowDragInView;
    }
    static DragCanvas()
    {
        Draggable = DependencyProperty.RegisterAttached("CanBeDragged", typeof(bool), typeof(DragCanvas), new UIPropertyMetadata(true));
    }
    
    #endregion // Constructor
    #region Mouse Handlers Overrides
    #region OnPreviewMouseLeftButtonDown
    protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
    {
        base.OnPreviewMouseLeftButtonDown(e); // call the handler of the base first
        m_IsDragInProgress = false;
        m_InitialCursorLocation = e.GetPosition(this); // Cache the mouse cursor location
        //check if the mouse was clicked on the ScrollBar, in which case let the ScrollBar remain its control. 
        if (null != GetParentOfType<ScrollBar>(e.OriginalSource as DependencyObject)) { return; }
        // Walk up the visual tree from the element that was clicked, 
        // looking for an element that is a direct child of the Canvas
        DraggedElement = FindCanvasChild(e.Source as DependencyObject);
        if (m_DraggedElement == null) { return; }
        m_ModificationDirection = ResolveOffset(Canvas.GetLeft(m_DraggedElement), Canvas.GetRight(m_DraggedElement), Canvas.GetTop(m_DraggedElement), Canvas.GetBottom(m_DraggedElement));
        // Set the Handled flag so that a control being dragged 
        // does not react to the mouse input
        e.Handled = true;
        if (m_ModificationDirection == ModificationDirection.None)
        {
            DraggedElement = null;
            return;
        }
        BringToFront(m_DraggedElement as UIElement);
        m_IsDragInProgress = true;
    }
    public static T GetParentOfType<T>(DependencyObject current) where T : DependencyObject
    {
        DependencyObject parent = current;
        do
        {
            if (parent is Visual)
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            else
            {
                parent = LogicalTreeHelper.GetParent(parent);
            }
            var result = parent as T;
            if (result != null)
            {
                return result;
            }
        } while (parent != null);
        return null;
    }
    #endregion // OnPreviewMouseLeftButtonDown
    #region OnPreviewMouseMove
    protected override void OnPreviewMouseMove(MouseEventArgs e)
    {
        base.OnPreviewMouseMove(e);
        // If no element is being dragged, there is nothing to do.
        if (m_DraggedElement == null || !m_IsDragInProgress)
        {
            return;
        }
        // Get the position of the mouse cursor, relative to the Canvas.
        Point cursorLocation = e.GetPosition(this);
        // These values will store the new offsets of the drag element.
        double _HorizontalOffset = Double.NaN;
        double _VerticalOffset = Double.NaN; ;
        #region Calculate Offsets
        Size _DraggedElemenetSize = m_DraggedElement.RenderSize;
        if ((m_ModificationDirection & ModificationDirection.Left) != 0)
        {
            _HorizontalOffset = m_OriginalLefOffset + (cursorLocation.X - m_InitialCursorLocation.X);
            if (m_DraggingMode == DraggingModes.AllowDragInView)
            {
                if (_HorizontalOffset < 0)
                {
                    _HorizontalOffset = 0;
                }
                else if ((_HorizontalOffset + _DraggedElemenetSize.Width) > this.ActualWidth)
                {
                    _HorizontalOffset = this.ActualWidth - _DraggedElemenetSize.Width;
                }
            }
            m_OriginalLefOffset = _HorizontalOffset;
            m_OriginalRightOffset = this.ActualWidth + _DraggedElemenetSize.Width - m_OriginalLefOffset;
        }
        else if ((m_ModificationDirection & ModificationDirection.Right) != 0)
        {
            _HorizontalOffset = m_OriginalRightOffset - (cursorLocation.X - m_InitialCursorLocation.X);
            if (m_DraggingMode == DraggingModes.AllowDragInView)
            {
                if (_HorizontalOffset < 0)
                {
                    _HorizontalOffset = 0;
                }
                else if ((_HorizontalOffset + _DraggedElemenetSize.Width) > this.ActualWidth)
                {
                    _HorizontalOffset = this.ActualWidth - _DraggedElemenetSize.Width;
                }
            }
            m_OriginalRightOffset = _HorizontalOffset;
            m_OriginalLefOffset = this.ActualWidth + _DraggedElemenetSize.Width - m_OriginalRightOffset;
        }
        if ((m_ModificationDirection & ModificationDirection.Top) != 0)
        {
            _VerticalOffset = m_OriginalTopOffset + (cursorLocation.Y - m_InitialCursorLocation.Y);
            if (m_DraggingMode == DraggingModes.AllowDragInView)
            {
                if (_VerticalOffset < 0)
                {
                    _VerticalOffset = 0;
                }
                else if ((_VerticalOffset + _DraggedElemenetSize.Height) > this.ActualHeight)
                {
                    _VerticalOffset = this.ActualHeight - _DraggedElemenetSize.Height;
                }
            }
            m_OriginalTopOffset = _VerticalOffset;
            m_OriginalBottomOffset = this.ActualHeight + _DraggedElemenetSize.Height - m_OriginalTopOffset;
        }
        else if ((m_ModificationDirection & ModificationDirection.Bottom) != 0)
        {
            _VerticalOffset = m_OriginalBottomOffset - (cursorLocation.Y - m_InitialCursorLocation.Y);
            if (m_DraggingMode == DraggingModes.AllowDragInView)
            {
                if (_VerticalOffset < 0)
                {
                    _VerticalOffset = 0;
                }
                else if ((_VerticalOffset + _DraggedElemenetSize.Height) > this.ActualHeight)
                {
                    _VerticalOffset = this.ActualHeight - _DraggedElemenetSize.Height;
                }
            }
            m_OriginalBottomOffset = _VerticalOffset;
            m_OriginalTopOffset = this.ActualHeight + _DraggedElemenetSize.Height - m_OriginalBottomOffset;
        }
        m_InitialCursorLocation = cursorLocation;
        #endregion // Calculate Offsets
        #region Move Drag Element
        if ((m_ModificationDirection & ModificationDirection.Left) != 0)
        {
            Canvas.SetLeft(m_DraggedElement, _HorizontalOffset);
        }
        else if ((m_ModificationDirection & ModificationDirection.Right) != 0)
        {
            Canvas.SetRight(m_DraggedElement, _HorizontalOffset);
        }
        if ((m_ModificationDirection & ModificationDirection.Top) != 0)
        {
            Canvas.SetTop(m_DraggedElement, _VerticalOffset);
        }
        else if ((m_ModificationDirection & ModificationDirection.Bottom) != 0)
        {
            Canvas.SetBottom(m_DraggedElement, _VerticalOffset);
        }
        #endregion // Move Drag Element
    }
    #endregion // OnPreviewMouseMove
    #region OnPreviewMouseLeftButtonUp
    protected override void OnPreviewMouseLeftButtonUp(MouseButtonEventArgs e)
    {
        base.OnPreviewMouseLeftButtonUp(e);
        // Reset the field whether the left or right mouse button was 
        // released, in case a context menu was opened on the drag element.
        m_IsDragInProgress = false;
        DraggedElement = null;
    }
    #endregion // OnPreviewMouseLeftButtonUp
    #region OnPreviewMouseRightButtonDown
    protected override void OnPreviewMouseRightButtonDown(MouseButtonEventArgs e)
    {
        base.OnPreviewMouseRightButtonDown(e);
    }
    #endregion // OnPreviewMouseRightButtonDown
    #region OnPreviewMouseRightButtonUp
    protected override void OnPreviewMouseRightButtonUp(MouseButtonEventArgs e)
    {
        base.OnPreviewMouseRightButtonUp(e);
    }
    #endregion // OnPreviewMouseRightButtonUp
    #endregion Mouse Handlers Overrides
    #region Public Methods
    /// <summary>
    /// Assigns the element a z-index which will ensure that 
    /// it is in front of every other element in the Canvas.
    /// The z-index of every element whose z-index is between 
    /// the element's old and new z-index will have its z-index 
    /// decremented by one.
    /// </summary>
    /// <param name="element">
    /// The element to be sent to the front of the z-order.
    /// </param>
    public void BringToFront(UIElement element)
    {
        UpdateZOrder(element, true);
    }
    /// <summary>
    /// Assigns the element a z-index which will ensure that 
    /// it is behind every other element in the Canvas.
    /// The z-index of every element whose z-index is between 
    /// the element's old and new z-index will have its z-index 
    /// incremented by one.
    /// </summary>
    /// <param name="element">
    /// The element to be sent to the back of the z-order.
    /// </param>
    public void SendToBack(UIElement element)
    {
        UpdateZOrder(element, false);
    }
    #endregion // Public Methods
    #region Private Helper Methods
        #region UpdateZOrder
    /// <summary>
    /// Helper method used by the BringToFront and SendToBack methods.
    /// </summary>
    /// <param name="element">
    /// The element to bring to the front or send to the back.
    /// </param>
    /// <param name="bringToFront">
    /// Pass true if calling from BringToFront, else false.
    /// </param>
    private void UpdateZOrder(UIElement element, bool bringToFront)
    {
            #region Safety Check
        if (element == null)
            throw new ArgumentNullException("element");
        if (!base.Children.Contains(element))
            throw new ArgumentException("Must be a child element of the Canvas.", "element");
            #endregion // Safety Check
            #region Calculate Z-Indexes And Offset
        // Determine the Z-Index for the target UIElement.
        int elementNewZIndex = -1;
        if (bringToFront)
        {
            foreach (UIElement elem in base.Children)
            {
                if (elem.Visibility != Visibility.Collapsed)
                {
                    ++elementNewZIndex;
                }
            }
        }
        else
        {
            elementNewZIndex = 0;
        }
        // Determine if the other UIElements' Z-Index 
        // should be raised or lowered by one. 
        int offset = (elementNewZIndex == 0) ? +1 : -1;
        int elementCurrentZIndex = Canvas.GetZIndex(element);
            #endregion // Calculate Z-Indici And Offset
            #region Update Z-Indexes
        // Update the Z-Index of every UIElement in the Canvas.
        foreach (UIElement childElement in base.Children)
        {
            if (childElement == element)
            {
                Canvas.SetZIndex(element, elementNewZIndex);
            }
            else
            {
                int zIndex = Canvas.GetZIndex(childElement);
                // Only modify the z-index of an element if it is  
                // in between the target element's old and new z-index.
                if (bringToFront && elementCurrentZIndex < zIndex || !bringToFront && zIndex < elementCurrentZIndex)
                {
                    Canvas.SetZIndex(childElement, zIndex + offset);
                }
            }
        }
            #endregion // Update Z-Indexes
    }
        #endregion // UpdateZOrder
        #region ResolveOffset
    /// <summary>
    /// Determines one component of a UIElement's location 
    /// within a Canvas (horizontal or vertical offset)
    /// and according to it reletive to which sides it may be relocated
    /// </summary>
    /// <param name="Left">
    /// The value of an offset relative to a Left side of the Canvas
    /// </param>
    /// <param name="Right">
    /// The value of the offset relative to the Right side of the Canvas
    /// </param>
    /// <param name="Top">
    /// The value of an offset relative to a Top side of the Canvas
    /// </param>
    /// <param name="Bottom">
    /// The value of the offset relative to the Bottom side of the Canvas
    /// </param>
    private ModificationDirection ResolveOffset(double Left, double Right, double Top, double Bottom)
    {
        // If the Canvas.Left and Canvas.Right attached properties 
        // are specified for an element, the 'Left' value is honored.
        // The 'Top' value is honored if both Canvas.Top and 
        // Canvas.Bottom are set on the same element.  If one 
        // of those attached properties is not set on an element, 
        // the default value is Double.NaN.
        m_OriginalLefOffset = Left;
        m_OriginalRightOffset = Right;
        m_OriginalTopOffset = Top;
        m_OriginalBottomOffset = Bottom;
        ModificationDirection result = ModificationDirection.None;
        if (!Double.IsNaN(m_OriginalLefOffset))
        {
            result |= ModificationDirection.Left;
        }
        if (!Double.IsNaN(m_OriginalRightOffset))
        {
            result |= ModificationDirection.Right;
        }
        if (!Double.IsNaN(m_OriginalTopOffset))
        {
            result |= ModificationDirection.Top;
        }
        if (!Double.IsNaN(m_OriginalBottomOffset))
        {
            result |= ModificationDirection.Bottom;
        }
        return result;
    }
        #endregion // ResolveOffset
        #region FindCanvasChild
    /// <summary>
    /// Walks up the visual tree starting with the specified DependencyObject, 
    /// looking for a UIElement which is a child of the Canvas.  If a suitable 
    /// element is not found, null is returned.  If the 'depObj' object is a 
    /// UIElement in the Canvas's Children collection, it will be returned.
    /// </summary>
    /// <param name="depObj">
    /// A DependencyObject from which the search begins.
    /// </param>
    private UIElement FindCanvasChild(DependencyObject depObj)
    {
        while (depObj != null)
        {
            // If the current object is a UIElement which is a child of the
            // Canvas, exit the loop and return it.
            UIElement elem = depObj as UIElement;
            if (elem != null && base.Children.Contains(elem))
            {
                break;
            }
            // VisualTreeHelper works with objects of type Visual or Visual3D.
            // If the current object is not derived from Visual or Visual3D,
            // then use the LogicalTreeHelper to find the parent element.
            if (depObj is Visual || depObj is Visual3D)
            {
                depObj = VisualTreeHelper.GetParent(depObj);
            }
            else
            {
                depObj = LogicalTreeHelper.GetParent(depObj);
            }
        }
        return depObj as UIElement;
    }
        #endregion // FindCanvasChild
    #endregion 
    }
