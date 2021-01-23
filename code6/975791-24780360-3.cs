      public static Object GetValueFromClassProperty(String typeHierarichy, Object parentClassObject)
      {
          foreach (String part in typeHierarichy.Split('.'))
          {
              if (parentClassObject == null) { return null; }
              Type type = parentClassObject.GetType();
              PropertyInfo info = type.GetProperty(part);
              if (info == null) { return null; }
              parentClassObject = info.GetValue(parentClassObject, null);
          }
          return parentClassObject;
      }
