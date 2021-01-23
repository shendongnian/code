	#pragma once
	#include "NativeEntity.h"
	#include <vector>
	namespace EntityLibrary {
		using namespace System;
	
		public ref class ManagedEntity {
		public:
			ManagedEntity();
			~ManagedEntity();
			
			array<double> ^GetVec();
		private:
			NativeEntity* nativeObj; // Our native object is thus being wrapped
		};
	}
