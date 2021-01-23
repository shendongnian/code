private CustomEntry _entry;
private double _yPos;
private double _width;
 2. Assign the value in `OnElementChanged`:
if (e.NewElement != null)
    _entry = e.NewElement as CustomEntry;
 3. In `OnElementPropertyChanged`, include the following:
if (e.PropertyName == "Width")
{
    _width = _entry.Width;
}
else if (e.PropertyName == "Height")
{
    _yPos = _entry.Height;
}
_line.Frame = new CGRect(0, _yPos, _width, 1f);
  [1]: https://stackoverflow.com/users/246557/root
