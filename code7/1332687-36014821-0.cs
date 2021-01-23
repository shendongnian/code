    using System;
    using System.Collections;
    using System.Runtime.Serialization;
    using System.Reflection;
    internal sealed class ObjectWalker: IEnumerable, IEnumerator
    {
      object current;
      readonly Stack stack = new Stack( );
      readonly ObjectIDGenerator idGenerator = new ObjectIDGenerator( );
      public ObjectWalker( object root )
      {
        Consider( root );
      }
      IEnumerator IEnumerable.GetEnumerator( )
      {
        return this;
      }
      void IEnumerator.Reset( )
      {
        throw new NotSupportedException( );
      }
      object IEnumerator.Current { get { return current; } }
      bool IEnumerator.MoveNext( )
      {
        const BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
        if ( stack.Count == 0 ) return false;
        if ( !IsLeaf( current = stack.Pop( ) ) )
        {
          foreach ( var fieldInfo in current.GetType( ).GetFields( flags ) )
          {
            Consider( fieldInfo.GetValue( current ) );
          }
        }
        return true;
      }
      private void Consider( object toConsider )
      {
        if ( toConsider == null ) return;
        bool firstOccurrence;
        idGenerator.GetId( toConsider, out firstOccurrence );
        if ( !firstOccurrence ) return;
        if ( toConsider.GetType( ).IsArray )
        {
          foreach ( var item in ( ( Array ) toConsider ) ) Consider( item );
        }
        else
        {
          stack.Push( toConsider );
        }
      }
      bool IsLeaf( object data )
      {
        Type t = data.GetType( );
        return
          t.IsPrimitive ||
          t.IsEnum ||
          t.IsPointer ||
          data is string;
      }
    }
