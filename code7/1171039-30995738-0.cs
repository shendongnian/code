    PS K:\> $a.gettype()|gm
		   TypeName: System.RuntimeType
		Name                           MemberType Definition
		----                           ---------- ----------
		AsType                         Method     type AsType()
		Clone                          Method     System.Object Clone(), System.Object ICloneable.Clone()
		Equals                         Method     bool Equals(System.Object obj), bool Equals(type o), bool _MemberInfo.Equa...
		FindInterfaces                 Method     type[] FindInterfaces(System.Reflection.TypeFilter filter, System.Object f...
		FindMembers                    Method     System.Reflection.MemberInfo[] FindMembers(System.Reflection.MemberTypes m...
		GetArrayRank                   Method     int GetArrayRank(), int _Type.GetArrayRank()
		GetConstructor                 Method     System.Reflection.ConstructorInfo GetConstructor(System.Reflection.Binding...
		GetConstructors                Method     System.Reflection.ConstructorInfo[] GetConstructors(System.Reflection.Bind...
		GetCustomAttributes            Method     System.Object[] GetCustomAttributes(bool inherit), System.Object[] GetCust...
		GetCustomAttributesData        Method     System.Collections.Generic.IList[System.Reflection.CustomAttributeData] Ge...
		GetDeclaredEvent               Method     System.Reflection.EventInfo GetDeclaredEvent(string name)
		GetDeclaredField               Method     System.Reflection.FieldInfo GetDeclaredField(string name)
		GetDeclaredMethod              Method     System.Reflection.MethodInfo GetDeclaredMethod(string name)
		GetDeclaredMethods             Method     System.Collections.Generic.IEnumerable[System.Reflection.MethodInfo] GetDe...
		GetDeclaredNestedType          Method     System.Reflection.TypeInfo GetDeclaredNestedType(string name)
		GetDeclaredProperty            Method     System.Reflection.PropertyInfo GetDeclaredProperty(string name)
		GetDefaultMembers              Method     System.Reflection.MemberInfo[] GetDefaultMembers(), System.Reflection.Memb...
		GetElementType                 Method     type GetElementType(), type _Type.GetElementType()
		GetEnumName                    Method     string GetEnumName(System.Object value)
		GetEnumNames                   Method     string[] GetEnumNames()
		GetEnumUnderlyingType          Method     type GetEnumUnderlyingType()
		GetEnumValues                  Method     array GetEnumValues()
		GetEvent                       Method     System.Reflection.EventInfo GetEvent(string name, System.Reflection.Bindin...
		GetEvents                      Method     System.Reflection.EventInfo[] GetEvents(System.Reflection.BindingFlags bin...
		GetField                       Method     System.Reflection.FieldInfo GetField(string name, System.Reflection.Bindin...
		GetFields                      Method     System.Reflection.FieldInfo[] GetFields(System.Reflection.BindingFlags bin...
		GetGenericArguments            Method     type[] GetGenericArguments()
		GetGenericParameterConstraints Method     type[] GetGenericParameterConstraints()
		GetGenericTypeDefinition       Method     type GetGenericTypeDefinition()
		GetHashCode                    Method     int GetHashCode(), int _MemberInfo.GetHashCode(), int _Type.GetHashCode()
		GetIDsOfNames                  Method     void _MemberInfo.GetIDsOfNames([ref] guid riid, System.IntPtr rgszNames, u...
		GetInterface                   Method     type GetInterface(string fullname, bool ignoreCase), type GetInterface(str...
		GetInterfaceMap                Method     System.Reflection.InterfaceMapping GetInterfaceMap(type ifaceType), System...
		GetInterfaces                  Method     type[] GetInterfaces(), type[] _Type.GetInterfaces()
		GetMember                      Method     System.Reflection.MemberInfo[] GetMember(string name, System.Reflection.Me...
		GetMembers                     Method     System.Reflection.MemberInfo[] GetMembers(System.Reflection.BindingFlags b...
		GetMethod                      Method     System.Reflection.MethodInfo GetMethod(string name, System.Reflection.Bind...
		GetMethods                     Method     System.Reflection.MethodInfo[] GetMethods(System.Reflection.BindingFlags b...
		GetNestedType                  Method     type GetNestedType(string fullname, System.Reflection.BindingFlags binding...
		GetNestedTypes                 Method     type[] GetNestedTypes(System.Reflection.BindingFlags bindingAttr), type[] ...
		GetObjectData                  Method     void GetObjectData(System.Runtime.Serialization.SerializationInfo info, Sy...
		GetProperties                  Method     System.Reflection.PropertyInfo[] GetProperties(System.Reflection.BindingFl...
		GetProperty                    Method     System.Reflection.PropertyInfo GetProperty(string name, System.Reflection....
		GetType                        Method     type GetType(), type _MemberInfo.GetType(), type _Type.GetType()
		GetTypeInfo                    Method     void _MemberInfo.GetTypeInfo(uint32 iTInfo, uint32 lcid, System.IntPtr ppT...
		GetTypeInfoCount               Method     void _MemberInfo.GetTypeInfoCount([ref] uint32 pcTInfo), void _Type.GetTyp...
		Invoke                         Method     void _MemberInfo.Invoke(uint32 dispIdMember, [ref] guid riid, uint32 lcid,...
		InvokeMember                   Method     System.Object InvokeMember(string name, System.Reflection.BindingFlags bin...
		IsAssignableFrom               Method     bool IsAssignableFrom(System.Reflection.TypeInfo typeInfo), bool IsAssigna...
		IsDefined                      Method     bool IsDefined(type attributeType, bool inherit), bool ICustomAttributePro...
		IsEnumDefined                  Method     bool IsEnumDefined(System.Object value)
		IsEquivalentTo                 Method     bool IsEquivalentTo(type other)
		IsInstanceOfType               Method     bool IsInstanceOfType(System.Object o), bool _Type.IsInstanceOfType(System...
		IsSubclassOf                   Method     bool IsSubclassOf(type type), bool _Type.IsSubclassOf(type c)
		MakeArrayType                  Method     type MakeArrayType(), type MakeArrayType(int rank)
		MakeByRefType                  Method     type MakeByRefType()
		MakeGenericType                Method     type MakeGenericType(Params type[] instantiation)
		MakePointerType                Method     type MakePointerType()
		ToString                       Method     string ToString(), string _MemberInfo.ToString(), string _Type.ToString()
		Assembly                       Property   System.Reflection.Assembly Assembly {get;}
		AssemblyQualifiedName          Property   string AssemblyQualifiedName {get;}
		Attributes                     Property   System.Reflection.TypeAttributes Attributes {get;}
		BaseType                       Property   type BaseType {get;}
		ContainsGenericParameters      Property   bool ContainsGenericParameters {get;}
		CustomAttributes               Property   System.Collections.Generic.IEnumerable[System.Reflection.CustomAttributeDa...
		DeclaredConstructors           Property   System.Collections.Generic.IEnumerable[System.Reflection.ConstructorInfo] ...
		DeclaredEvents                 Property   System.Collections.Generic.IEnumerable[System.Reflection.EventInfo] Declar...
		DeclaredFields                 Property   System.Collections.Generic.IEnumerable[System.Reflection.FieldInfo] Declar...
		DeclaredMembers                Property   System.Collections.Generic.IEnumerable[System.Reflection.MemberInfo] Decla...
		DeclaredMethods                Property   System.Collections.Generic.IEnumerable[System.Reflection.MethodInfo] Decla...
		DeclaredNestedTypes            Property   System.Collections.Generic.IEnumerable[System.Reflection.TypeInfo] Declare...
		DeclaredProperties             Property   System.Collections.Generic.IEnumerable[System.Reflection.PropertyInfo] Dec...
		DeclaringMethod                Property   System.Reflection.MethodBase DeclaringMethod {get;}
		DeclaringType                  Property   type DeclaringType {get;}
		FullName                       Property   string FullName {get;}
		GenericParameterAttributes     Property   System.Reflection.GenericParameterAttributes GenericParameterAttributes {g...
		GenericParameterPosition       Property   int GenericParameterPosition {get;}
		GenericTypeArguments           Property   type[] GenericTypeArguments {get;}
		GenericTypeParameters          Property   type[] GenericTypeParameters {get;}
		GUID                           Property   guid GUID {get;}
		HasElementType                 Property   bool HasElementType {get;}
		ImplementedInterfaces          Property   System.Collections.Generic.IEnumerable[type] ImplementedInterfaces {get;}
		IsAbstract                     Property   bool IsAbstract {get;}
		IsAnsiClass                    Property   bool IsAnsiClass {get;}
		IsArray                        Property   bool IsArray {get;}
		IsAutoClass                    Property   bool IsAutoClass {get;}
		IsAutoLayout                   Property   bool IsAutoLayout {get;}
		IsByRef                        Property   bool IsByRef {get;}
		IsClass                        Property   bool IsClass {get;}
		IsCOMObject                    Property   bool IsCOMObject {get;}
		IsConstructedGenericType       Property   bool IsConstructedGenericType {get;}
		IsContextful                   Property   bool IsContextful {get;}
		IsEnum                         Property   bool IsEnum {get;}
		IsExplicitLayout               Property   bool IsExplicitLayout {get;}
		IsGenericParameter             Property   bool IsGenericParameter {get;}
		IsGenericType                  Property   bool IsGenericType {get;}
		IsGenericTypeDefinition        Property   bool IsGenericTypeDefinition {get;}
		IsImport                       Property   bool IsImport {get;}
		IsInterface                    Property   bool IsInterface {get;}
		IsLayoutSequential             Property   bool IsLayoutSequential {get;}
		IsMarshalByRef                 Property   bool IsMarshalByRef {get;}
		IsNested                       Property   bool IsNested {get;}
		IsNestedAssembly               Property   bool IsNestedAssembly {get;}
		IsNestedFamANDAssem            Property   bool IsNestedFamANDAssem {get;}
		IsNestedFamily                 Property   bool IsNestedFamily {get;}
		IsNestedFamORAssem             Property   bool IsNestedFamORAssem {get;}
		IsNestedPrivate                Property   bool IsNestedPrivate {get;}
		IsNestedPublic                 Property   bool IsNestedPublic {get;}
		IsNotPublic                    Property   bool IsNotPublic {get;}
		IsPointer                      Property   bool IsPointer {get;}
		IsPrimitive                    Property   bool IsPrimitive {get;}
		IsPublic                       Property   bool IsPublic {get;}
		IsSealed                       Property   bool IsSealed {get;}
		IsSecurityCritical             Property   bool IsSecurityCritical {get;}
		IsSecuritySafeCritical         Property   bool IsSecuritySafeCritical {get;}
		IsSecurityTransparent          Property   bool IsSecurityTransparent {get;}
		IsSerializable                 Property   bool IsSerializable {get;}
		IsSpecialName                  Property   bool IsSpecialName {get;}
		IsUnicodeClass                 Property   bool IsUnicodeClass {get;}
		IsValueType                    Property   bool IsValueType {get;}
		IsVisible                      Property   bool IsVisible {get;}
		MemberType                     Property   System.Reflection.MemberTypes MemberType {get;}
		MetadataToken                  Property   int MetadataToken {get;}
		Module                         Property   System.Reflection.Module Module {get;}
		Name                           Property   string Name {get;}
		Namespace                      Property   string Namespace {get;}
		ReflectedType                  Property   type ReflectedType {get;}
		StructLayoutAttribute          Property   System.Runtime.InteropServices.StructLayoutAttribute StructLayoutAttribute...
		TypeHandle                     Property   System.RuntimeTypeHandle TypeHandle {get;}
		TypeInitializer                Property   System.Reflection.ConstructorInfo TypeInitializer {get;}
		UnderlyingSystemType           Property   type UnderlyingSystemType {get;}
		PS K:\> $a.gettype().isfixedsize
		PS K:\> $a.isfixedsize
		False
		PS K:\> get-member -InputObject $a
		   TypeName: System.Collections.Hashtable
		Name              MemberType            Definition
		----              ----------            ----------
		Add               Method                void Add(System.Object key, System.Object value), void IDictionary.Add(Syste...
		Clear             Method                void Clear(), void IDictionary.Clear()
		Clone             Method                System.Object Clone(), System.Object ICloneable.Clone()
		Contains          Method                bool Contains(System.Object key), bool IDictionary.Contains(System.Object key)
		ContainsKey       Method                bool ContainsKey(System.Object key)
		ContainsValue     Method                bool ContainsValue(System.Object value)
		CopyTo            Method                void CopyTo(array array, int arrayIndex), void ICollection.CopyTo(array arra...
		Equals            Method                bool Equals(System.Object obj)
		GetEnumerator     Method                System.Collections.IDictionaryEnumerator GetEnumerator(), System.Collections...
		GetHashCode       Method                int GetHashCode()
		GetObjectData     Method                void GetObjectData(System.Runtime.Serialization.SerializationInfo info, Syst...
		GetType           Method                type GetType()
		OnDeserialization Method                void OnDeserialization(System.Object sender), void IDeserializationCallback....
		Remove            Method                void Remove(System.Object key), void IDictionary.Remove(System.Object key)
		ToString          Method                string ToString()
		Item              ParameterizedProperty System.Object Item(System.Object key) {get;set;}
		Count             Property              int Count {get;}
		IsFixedSize       Property              bool IsFixedSize {get;}
		IsReadOnly        Property              bool IsReadOnly {get;}
		IsSynchronized    Property              bool IsSynchronized {get;}
		Keys              Property              System.Collections.ICollection Keys {get;}
		SyncRoot          Property              System.Object SyncRoot {get;}
		Values            Property              System.Collections.ICollection Values {get;}
