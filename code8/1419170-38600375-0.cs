      /// <summary>
      ///    Indicates whether the current object is equal to another object of the same type.
      /// </summary>
      /// <returns> true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false. </returns>
      /// <param name="other"> An object to compare with this object. </param>
      public bool Equals( EntityBase other ) {
         return !ReferenceEquals(other, null)
                && Id.Equals(other.Id);
      }
      /// <summary>
      ///    Serves as a hash function for a particular type.
      /// </summary>
      /// <returns> A hash code for the current <see cref="T:System.Object" />. </returns>
      /// <filterpriority> 2 </filterpriority>
      public override int GetHashCode() {
         return Id.GetHashCode();
      }
      /// <summary>
      ///    Determines whether the specified <see cref="T:System.Object" /> is equal to the current <see cref="T:System.Object" />.
      /// </summary>
      /// <returns> true if the specified object is equal to the current object; otherwise, false. </returns>
      /// <param name="obj"> The object to compare with the current object. </param>
      /// <filterpriority> 2 </filterpriority>
      public override bool Equals( object obj ) {
         return Equals(obj as EntityBase);
      }
      /// <summary>
      ///    Determines if the <paramref name="left" /> instance is considered equal to the <paramref name="right" /> object.
      /// </summary>
      /// <param name="left"> The instance on the left of the equality operator. </param>
      /// <param name="right"> The instance on the right of the equality operator. </param>
      /// <returns> True if the instances are considered equal, otherwise false. </returns>
      public static bool operator ==( EntityBase left, EntityBase right ) {
         return ReferenceEquals(left, null)
            ? ReferenceEquals(right, null)
            : left.Equals(right);
      }
      /// <summary>
      ///    Determines if the <paramref name="left" /> instance is considered unequal to the <paramref name="right" /> object.
      /// </summary>
      /// <param name="left"> The instance on the left of the inequality operator. </param>
      /// <param name="right"> The instance on the right of the inequality operator. </param>
      /// <returns> True if the instances are considered unequal, otherwise false. </returns>
      public static bool operator !=( EntityBase left, EntityBase right ) {
         return !(left == right);
      }
