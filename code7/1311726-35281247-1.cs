        private class ByTrackingNumberAndOrderComparer : IEqualityComparer<Foo>
        {
            public bool Equals(Foo x, Foo y)
            {
                return string.Equals(x.trackingNumber, y.trackingNumber)
                    && string.Equals(x.orderNumber, y.orderNumber);
            }
            public int GetHashCode(Foo obj)
            {
                return (obj.trackingNumber == null ? 0 : obj.trackingNumber.GetHashCode())
                    ^ 397 ^ (obj.orderNumber == null ? 0 : obj.orderNumber.GetHashCode());
            }
        }
